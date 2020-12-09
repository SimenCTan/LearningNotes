using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GrpcGreeter;
using System.Threading;
using Grpc.Core;

namespace GrpcUnitTest.FunctionalTest
{
    [TestFixture]
    public class GreeterServiceTests:FunctionalTestBase
    {
        [Test]
        public async Task SayHelloTest()
        {
            // init
            var client = new Greeter.GreeterClient(Channel);

            // act
            var response = await client.SayHelloAsync(new HelloRequest { Name = "test" });

            // assert
            Assert.AreEqual("Hello test", response.Message);
        }

        [Test]
        public async Task StreamingFromServiceTest()
        {
            //arrange
            var client = new Greeter.GreeterClient(Channel);
            var cts = new CancellationTokenSource();
            var hasMessage = false;
            var callCancelled = false;

            // act
            using var call = client.StreamingFromService(new ExampleRequest {PageIndex=1,PageSize=10,IsDescending=false },cancellationToken:cts.Token);
            try
            {
                await foreach (var message in call.ResponseStream.ReadAllAsync())
                {
                    hasMessage = true;
                    cts.Cancel();
                }
            }
            catch (OperationCanceledException ex)
            {
                callCancelled = true;
            }

            // assert
            Assert.IsTrue(callCancelled);
            Assert.IsTrue(hasMessage);
        }

        [Test]
        public async Task StreamingFromClientTest()
        {
            // arrange
            var client = new Greeter.GreeterClient(Channel);
            var indexs = new[] { 1, 2,3 };
            ExampleResponse exampleResponse;

            // act
            using var call = client.StreamingFromClient();
            foreach (var index in indexs)
            {
                await call.RequestStream.WriteAsync(new ExampleRequest { PageIndex = index, PageSize = 10, IsDescending = false });
            }
            await call.RequestStream.CompleteAsync();
            exampleResponse = await call;
            Assert.IsTrue(exampleResponse.Age > 1);
        }

        [Test]
        public async Task StreamingBothWaysTest()
        {
            // arrange
            var client = new Greeter.GreeterClient(Channel);
            var indexs = new[] { 1, 2, 3 };
            var ages = new List<int?>();

            // act
            using var call = client.StreamingBothWays();
            foreach (var index in indexs)
            {
                await call.RequestStream.WriteAsync(new ExampleRequest { PageIndex = index, PageSize = 10, IsDescending = false });
                Assert.IsTrue(await call.ResponseStream.MoveNext());
                ages.Add(call.ResponseStream.Current.Age);
            }
            await call.RequestStream.CompleteAsync();

            //assert
            Assert.AreEqual(ages.Count, 3);
        }
    }
}
