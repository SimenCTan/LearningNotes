using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GrpcGreeter;
using System;

namespace ProtoLib
{
    public static class IServiceCollectionsExtensions
    {
        public static IServiceCollection AddGrpcService(this IServiceCollection services,IConfiguration configuration)
        {
            var address = configuration.GetValue<string>("greetergrpc");
            services.AddGrpcClient<Greeter.GreeterClient>(o =>
            {
                o.Address = new Uri(address);
            });
            // .AddInterceptor(() => new LoggingInterceptor());
            return services;
        }
    }
}
