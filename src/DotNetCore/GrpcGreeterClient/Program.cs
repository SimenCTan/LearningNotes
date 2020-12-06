using Grpc.Core;
using Grpc.Net.Client;
using GrpcGreeter;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new  Greeter.GreeterClient(channel);
            try
            {
                var reply = await client.SayHelloAsync(new HelloRequest { Name = "GrpcGreeterClient" }, deadline: DateTime.UtcNow.AddSeconds(2));
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
                using var call = client.StreamingFromService(new ExampleRequest { PageIndex = 1, PageSize = 10, IsDescending = false }, cancellationToken: tokenSource.Token);
                while (await call.ResponseStream.MoveNext())
                {
                    Console.WriteLine($"response age {call.ResponseStream.Current.Age}");
                    if (call.ResponseStream.Current.Age > 80)
                    {
                        tokenSource.Cancel();
                    }
                }
            }
            catch (RpcException ex)
            {
                Console.WriteLine($"request cancel by client {ex.Message}");
            }

            // stream from client
            using var clientCall = client.StreamingFromClient();
            for (var i = 0; i < 5;i++)
            {
                await clientCall.RequestStream.WriteAsync(new ExampleRequest { PageIndex = i, PageSize = i, IsDescending = false });
            }
            
            await clientCall.RequestStream.CompleteAsync();
            var clientResponse = clientCall.GetTrailers();
            Console.WriteLine($"client end meta data {clientResponse.GetValue("my-trailer-name")}");

            // both stream
            using var bothstream = client.StreamingBothWays();
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
    }
}
