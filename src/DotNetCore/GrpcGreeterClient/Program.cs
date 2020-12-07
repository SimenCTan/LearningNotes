using Grpc.Core;
using Grpc.Net.Client;
using GrpcGreeter;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace GrpcGreeterClient
{
    class Program
    {
        private static string _token;

        // The port number(5001) must match the port of the gRPC server.
        private const string Address = "localhost:5001";

        static async Task Main(string[] args)
        {
            using var channel = CreateAuthenticatedChannel("https://localhost:5001");

            //using var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
            //{
            //    MaxSendMessageSize = 10 * 1024 * 1024,
            //    ThrowOperationCanceledOnCancellation = true
            //});

            _token = await Authenticate();
            var client = new  Greeter.GreeterClient(channel);
            
            try
            {
                var reply = await client.SayHelloAsync(new HelloRequest { Name = "GrpcGreeterClient" });
                Console.WriteLine("Greeting: " + reply.Message);
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded)
            {
                Console.WriteLine("Greeting timeout.");
            }

           
            // stream from service
            try
            {
                var tokenSource = new CancellationTokenSource();
                var call = client.StreamingFromService(new ExampleRequest { PageIndex = 1, PageSize = 10, IsDescending = false },cancellationToken:tokenSource.Token);
                while (await call.ResponseStream.MoveNext())
                {
                    Console.WriteLine($"response age {call.ResponseStream.Current.Age}");
                    if (call.ResponseStream.Current.Age > 80)
                    {
                        tokenSource.Cancel();
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine($"request cancel by client {ex.Message}");
            }

            // stream from client
            var clientCall = client.StreamingFromClient();
            for (var i = 0; i < 5;i++)
            {
                await clientCall.RequestStream.WriteAsync(new ExampleRequest { PageIndex = i, PageSize = i, IsDescending = false });
            }
            
            // await clientCall.RequestStream.CompleteAsync();
            //var clientResponse = clientCall.GetTrailers();
            //Console.WriteLine($"client end meta data {clientResponse.GetValue("my-trailer-name")}");

            
            // both stream
            var bothstream = client.StreamingBothWays();
            Console.WriteLine($"Starting background task to receive messages");
            var readTask = Task.Run(async () =>
            {
                await foreach (var response in bothstream.ResponseStream.ReadAllAsync())
                {
                    Console.WriteLine($"response age {response.Age}");
                }
            });

            Console.WriteLine("Starting to send messages");
            Console.WriteLine("Type a message to echo then press enter.");
            while (true)
            {
                var result = Console.ReadLine();
                if (string.IsNullOrEmpty(result))
                {
                    break;
                }
                await bothstream.RequestStream.WriteAsync(new ExampleRequest { PageIndex = 100, PageSize = 200, IsDescending = true });
            }
            Console.WriteLine("Disconnecting");
            await bothstream.RequestStream.CompleteAsync();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static GrpcChannel CreateAuthenticatedChannel(string address)
        {
            var credentials = CallCredentials.FromInterceptor((context, metadata) =>
            {
                if (!string.IsNullOrEmpty(_token))
                {
                    metadata.Add("Authorization", $"Bearer {_token}");
                }
                return Task.CompletedTask;
            });
            var loggerFactory = LoggerFactory.Create(logging =>
            {
                logging.SetMinimumLevel(LogLevel.Debug);
            });
            var channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Create(new SslCredentials(), credentials),
                ThrowOperationCanceledOnCancellation = true,
                LoggerFactory = loggerFactory
            });
            return channel;
        }

        private static async Task<string> Authenticate()
        {
            Console.WriteLine($"Authenticating as {Environment.UserName}...");
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"https://{Address}/generateJwtToken?name={HttpUtility.UrlEncode(Environment.UserName)}"),
                Method = HttpMethod.Get,
                Version = new Version(2, 0)
            };
            var tokenResponse = await httpClient.SendAsync(request);
            tokenResponse.EnsureSuccessStatusCode();

            var token = await tokenResponse.Content.ReadAsStringAsync();
            Console.WriteLine("Successfully authenticated.");

            return token;
        }
    }
}
