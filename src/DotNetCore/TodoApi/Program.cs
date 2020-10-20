using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TodoApi.DIServices;

namespace TodoApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var serviceScope = host.Services.CreateScope();
            try
            {
                var operation = serviceScope.ServiceProvider.GetRequiredService<IOperationTransien>();
                var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogInformation(operation.OperationId);
            }
            catch (Exception ex)
            {
                var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError($"error happen {ex.Message}");
            }
            //host.Run();
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, configBuilder) =>
                {
                    configBuilder.AddJsonFile("appsettings.json", optional: false)
                    .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true)
                    .AddCommandLine(args)
                    .AddEnvironmentVariables();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel((webHostBuilderContext, options) =>
                    {
                        options.Limits.MaxRequestBodySize = 20000000;
                    });
                    webBuilder.CaptureStartupErrors(true);
                    //webBuilder.UseSetting(WebHostDefaults.HostingStartupAssembliesKey, "assembly1;assembly2");
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging((hostContext,configBuilder)=>
                {
                    configBuilder.ClearProviders();
                    //configBuilder.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                    //configBuilder.AddConsole();
                });


        //public static IHostBuilder CreateGenerateBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //    .ConfigureServices((hostcontext, services) =>
        //    {
        //        services.AddHostedService<worker>();
        //    });
    }
}
