using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MvcMovies.Data;

namespace MvcMovies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppContext.SetSwitch("Microsoft.AspNetCore.Routing.UseCorrectCatchAllBehavior",true);
            var host = CreateHostBuilder(args).Build();
            using var service = host.Services.CreateScope();
            var serviceProvider = service.ServiceProvider;
            try
            {
                SeedData.Initialize(serviceProvider);
            }
            catch (DbException dbEx)
            {
                var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError($"Init error message {dbEx.Message}");
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
