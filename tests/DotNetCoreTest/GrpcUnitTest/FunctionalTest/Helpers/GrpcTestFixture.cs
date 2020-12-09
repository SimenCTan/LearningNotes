using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;

namespace GrpcUnitTest.FunctionalTest.Helpers
{
    public delegate void LogMessage(LogLevel logLevel, string categoryName, EventId eventId, string message, Exception exception);
    public class GrpcTestFixture<TStartup> : IDisposable where TStartup : class
    {
        private readonly TestServer _server;
        private readonly IHost _host;
        public event LogMessage? LoggedMessage;
        public HttpMessageHandler Handler { get; }
        public LoggerFactory LoggerFactory { get; }

        public GrpcTestFixture() : this(null) { }

        public GrpcTestFixture(Action<IServiceCollection>? initialConfigureServices)
        {
            LoggerFactory = new LoggerFactory();
            LoggerFactory.AddProvider(new ForwardingLoggerProvider((logLevel, category, eventId, message, exception) =>
            {
                LoggedMessage?.Invoke(logLevel, category, eventId, message, exception);
            }));
            var builder = new HostBuilder()
                            .ConfigureServices(service =>
                            {
                                initialConfigureServices?.Invoke(service);
                                service.AddSingleton<ILoggerFactory>(LoggerFactory);
                            })
                            .ConfigureWebHostDefaults(webhost =>
                            {
                                webhost.UseTestServer()
                                .UseStartup<TStartup>();
                            });
            _host = builder.Start();
            _server = _host.GetTestServer();
            Handler = _server.CreateHandler();
        }
        public void Dispose()
        {
            Handler.Dispose();
            _host.Dispose();
            _server.Dispose();
        }

        public IDisposable GetTestContext()
        {
            return new GrpcTestContext<TStartup>(this);
        }
    }
}
