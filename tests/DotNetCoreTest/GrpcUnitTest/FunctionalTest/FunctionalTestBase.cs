using System;
using System.Collections.Generic;
using System.Text;
using Grpc.Net.Client;
using GrpcUnitTest.FunctionalTest.Helpers;
using GrpcGreeter;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace GrpcUnitTest.FunctionalTest
{
    public class FunctionalTestBase
    {
        private GrpcChannel? _channel;
        private IDisposable? _testContext;
        protected GrpcTestFixture<Startup> Fixture { get; private set; } = default!;
        protected ILoggerFactory LoggerFactory => Fixture.LoggerFactory;
        protected GrpcChannel Channel => _channel ??= CreateGrpcChannel();
        protected GrpcChannel CreateGrpcChannel()
        {
            return GrpcChannel.ForAddress("http://localhost", new GrpcChannelOptions
            {
                LoggerFactory = LoggerFactory,
                HttpHandler=Fixture.Handler,
                ThrowOperationCanceledOnCancellation=true
            });
        }
        protected virtual void ConfigureServices(IServiceCollection services)
        {

        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Fixture = new GrpcTestFixture<Startup>(ConfigureServices);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Fixture.Dispose();
        }

        [SetUp]
        public void SetUp()
        {
            _testContext = Fixture.GetTestContext();
        }

        [TearDown]
        public void TearDown()
        {
            _testContext?.Dispose();
            _channel = null;
        }
    }
}
