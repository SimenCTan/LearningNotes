using NUnit.Framework;
using GrpcGreeter;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Tests.UnitTests.Helpers;

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

        }
    }
}
