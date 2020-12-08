using NUnit.Framework;
using GrpcGreeter;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Tests.UnitTests.Helpers;
using GrpcUnitTest.Helpers;
using System.Collections.Generic;
using System;

namespace GrpcUnitTest
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SayHelloTest()
        {
            // arrange
            var service = new GreeterService(NullLoggerFactory.Instance);

            // act
            var response = await service.SayHello(new HelloRequest { Name = "test" }, TestServerCallContext.Create());

            // Assert
            Assert.AreEqual("Hello test", response.Message);
        }

        [Test]
        public async Task StreamingFromServiceTest()
        {
            var service = new GreeterService(NullLoggerFactory.Instance);
            var cts = new CancellationTokenSource();
            var callcontext = TestServerCallContext.Create(cancellationToken: cts.Token);
            var responseStream = new TestServerStreamWriter<ExampleResponse>(callcontext);

            try
            {


                // act
                using var call = service.StreamingFromService(new ExampleRequest { PageIndex = 1, PageSize = 10, IsDescending = false }, responseStream, callcontext);

                // assert
                Assert.IsFalse(call.IsCompletedSuccessfully, "Method should run until cancelled.");
                _ = Task.Delay(10000);
                cts.Cancel();
                await call;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex {ex.Message}");
            }
            
            responseStream.Complete();
            var allMessage = new List<ExampleResponse>();
            await foreach (var message in responseStream.ReadAllAsync())
            {
                allMessage.Add(message);
            }

            Assert.IsTrue(allMessage.Count > 0);
        }

        [Test]
        public async Task StreamingFromClientTest()
        {
            // init
            var server = new GreeterService(NullLoggerFactory.Instance);

            var callContext = TestServerCallContext.Create();
            var requestStream = new TestAsyncStreamReader<ExampleRequest>(callContext);

            // act
            using var call = server.StreamingFromClient(requestStream, callContext);
            requestStream.AddMessage(new ExampleRequest { PageIndex = 1, PageSize = 10, IsDescending = false });
            requestStream.AddMessage(new ExampleRequest { PageIndex = 2, PageSize = 10, IsDescending = false });
            requestStream.AddMessage(new ExampleRequest { PageIndex = 3, PageSize = 10, IsDescending = false });
            requestStream.AddMessage(new ExampleRequest { PageIndex = 4, PageSize = 10, IsDescending = false });
            requestStream.Complete();

            // Assert
            var response = await call;
            Assert.IsTrue(response.Age > 1);
        }

        [Test]
        public async Task StreamingBothWaysTest()
        {
            // init
            var server = new GreeterService(NullLoggerFactory.Instance);
            var callContext = TestServerCallContext.Create();
            var requstStream = new TestAsyncStreamReader<ExampleRequest>(callContext);
            var responseStream = new TestServerStreamWriter<ExampleResponse>(callContext);

            // act
            using var call = server.StreamingBothWays(requstStream, responseStream, callContext);
            requstStream.AddMessage(new ExampleRequest { PageIndex = 1, PageSize = 10, IsDescending = false });
            Assert.IsTrue((await responseStream.ReadNextAsync()).Age > 1);
            requstStream.Complete();
            await call;
            responseStream.Complete();
            Assert.IsNull(await responseStream.ReadNextAsync());
        }
    }
}
