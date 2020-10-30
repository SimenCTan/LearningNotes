using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TodoApi.DIServices;
using TodoApi.Extensions;

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

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var Dict = new Dictionary<string, string>
            {
               {"MyKey", "Dictionary MyKey Value"},
               {"Position:Title", "Dictionary_Title"},
               {"Position:Name", "Dictionary_Name" },
               {"Logging:LogLevel:Default", "Warning"}
            };

            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, configBuilder) =>
                {
                    configBuilder.AddInMemoryCollection(Dict);

                    // set config dirctory
                    configBuilder.SetBasePath(Path.Combine(AppContext.BaseDirectory, "Configs"));

                    //clear
                    configBuilder.Sources.Clear();

                    // ini file
                    configBuilder.AddIniFile("myinifile.ini", optional: false, reloadOnChange: true)
                        .AddIniFile($"myinifile.{hostContext.HostingEnvironment.EnvironmentName}.ini", optional: true, reloadOnChange: true);

                    // json file
                    configBuilder.AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
                    .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", reloadOnChange: true, optional: true);

                    // xml file
                    configBuilder.AddXmlFile("myxmlfile.xml", optional: false, reloadOnChange: true)
                        .AddXmlFile($"myxmlfile.{hostContext.HostingEnvironment.EnvironmentName}.xml", optional: true, reloadOnChange: true);

                    // ef config
                    configBuilder.AddEFConfiguration(options => options.UseInMemoryDatabase("InMemoryDb"));

                    configBuilder.AddEnvironmentVariables();

                    if (args != null)
                    {
                        configBuilder.AddCommandLine(args);
                    }
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
                .ConfigureLogging((hostContext, configBuilder) =>
                {
                    configBuilder.ClearProviders();
                    //configBuilder.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                    configBuilder.AddConsole(options => options.IncludeScopes = true);
                    configBuilder.SetMinimumLevel(LogLevel.Information);
                    configBuilder.AddFilter((provider, category, logLevel) =>
                    {
                        // add log filter
                        if (provider.Contains("ConsoleLoggerProvider")
                        && category.Contains("Controller")
                        && logLevel >= LogLevel.Information)
                        {
                            return true;
                        }
                        else if (provider.Contains("ConsoleLoggerProvider")
                        && category.Contains("Microsoft")
                        && logLevel >= LogLevel.Information)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    });
                });
        }

        //public static IHostBuilder CreateGenerateBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //    .ConfigureServices((hostcontext, services) =>
        //    {
        //        services.AddHostedService<worker>();
        //    });
    }
}
