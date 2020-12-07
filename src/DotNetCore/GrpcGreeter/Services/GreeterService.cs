using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GrpcGreeter
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger _logger;
        public GreeterService(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger<GreeterService>();
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        [Authorize]
        public override async Task StreamingFromService(ExampleRequest request, IServerStreamWriter<ExampleResponse> responseStream, ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                await responseStream.WriteAsync(new ExampleResponse { Age = new Random().Next(1,100) });
                await Task.Delay(TimeSpan.FromSeconds(1), context.CancellationToken);
            }
        }

        [Authorize]
        public override async Task<ExampleResponse> StreamingFromClient(IAsyncStreamReader<ExampleRequest> requestStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                var message = requestStream.Current;
                Console.WriteLine($"request message pageindex: {message.PageIndex},pagesize: {message.PageSize},order {message.IsDescending}");
            }
            return new ExampleResponse { Age = 99 };
        }

        [Authorize]
        public override async Task StreamingBothWays(IAsyncStreamReader<ExampleRequest> requestStream, IServerStreamWriter<ExampleResponse> responseStream, ServerCallContext context)
        {
            await foreach (var message in requestStream.ReadAllAsync())
            {
                Console.WriteLine($"request message pageindex: {message.PageIndex},pagesize: {message.PageSize},order {message.IsDescending}");
                await responseStream.WriteAsync(new ExampleResponse { Age = new Random().Next(1, 100) });
            }

            // Read requests in a background task.
            //var readTask = Task.Run(async () =>
            //{
            //    await foreach (var message in requestStream.ReadAllAsync())
            //    {
            //        // Process request.
            //    }
            //});

            //// Send responses until the client signals that it is complete.
            //while (!readTask.IsCompleted)
            //{
            //    await responseStream.WriteAsync(new ExampleResponse());
            //    await Task.Delay(TimeSpan.FromSeconds(1), context.CancellationToken);
            //}
        }
    }
}
