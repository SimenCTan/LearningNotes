using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Threading.Tasks;
using TodoApi.CustomLoggers;
using TodoApi.DIServices;
using TodoApi.Middlewares;
using TodoApi.Models;

namespace TodoApi
{
    public class Startup
    {
        private readonly IWebHostEnvironment env;
        public Startup(IConfiguration configuration,IWebHostEnvironment webHost)
        {
            Configuration = configuration;
            env = webHost;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(option =>
            {
                option.UseInMemoryDatabase("TodoList");
            });
            Configuration.GetSection("Logging");
            services.AddTransient<IStartupFilter, RequestSetOptionsStartUpFilter>();
            services.AddControllers()
                .AddNewtonsoftJson(setupAction=> {
                    setupAction.UseMemberCasing();
                });
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "todo api",
                    Version = "v1"
                });
            });
            services.AddTransient<IOperationTransien, Operation>();
            services.AddScoped<IOperationScope, Operation>();

            services.AddSingleton<IOperationSingleton, Operation>();

            // config logger
            //services.AddSingleton<IMyService>((container) =>
            //{
            //    var logger = container.GetRequiredService<ILogger<MyService>>();
            //    return new MyService() { Logger = logger };
            //});
            services.Configure<PositionOptions>(Configuration.GetSection(PositionOptions.Position));

            // IConfigureNamedOptions
            services.Configure<TopItemSettings>(TopItemSettings.Month, Configuration.GetSection("TopItem:Month"));
            services.Configure<TopItemSettings>(TopItemSettings.Year, Configuration.GetSection("TopItem:Year"));

            // di config
            services.AddOptions<MyConfigOptions>()
                .Bind(Configuration.GetSection(MyConfigOptions.MyConfig))
                .ValidateDataAnnotations();

            // server add health check
            services.AddHealthChecks()
                .AddPrivateMemoryHealthCheck(1024L * 1024L * 256L);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,ILogger<Startup> logger,ILoggerFactory loggerFactory)
        {
            // Default registration.
            loggerFactory.AddProvider(new ColorConsoleLoggerProvider(
                                      new ColorConsoleLoggerConfiguration
                                      {
                                          LogLevel = LogLevel.Error,
                                          Color = ConsoleColor.Red
                                      }));

            // Custom registration with default values.
            loggerFactory.AddColorConsoleLogger();

            // Custom registration with a new configuration instance.
            loggerFactory.AddColorConsoleLogger(new ColorConsoleLoggerConfiguration
            {
                LogLevel = LogLevel.Debug,
                Color = ConsoleColor.Gray
            });

            // Custom registration with a configuration object.
            loggerFactory.AddColorConsoleLogger(c =>
            {
                c.LogLevel = LogLevel.Information;
                c.Color = ConsoleColor.Blue;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            logger.LogInformation("test logger");
            app.Use(async (context, next) =>
            {
                Console.WriteLine($"This is a middlerware");
                await next.Invoke();
            });

            // branch
            // app.Map("/swagger", HandRequestDel);
            app.MapWhen(context => context.Request.Headers.ContainsKey("Query"), HandRequestDel);
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync($"This is terminal middlerware");
            //});

            // cors
            app.UseCors();

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "to do api");
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // query endpoints
            app.Use(next => httpContext =>
            {
                var endPoints = httpContext.GetEndpoint();
                if (endPoints is null)
                {
                    return Task.CompletedTask;
                }
                Console.WriteLine($"Endpoints:{endPoints.DisplayName}");
                if (endPoints is RouteEndpoint routeEndpoint)
                {
                    Console.WriteLine($"Endpoint has route pattern:" + routeEndpoint.RoutePattern.RawText);
                }
                foreach (var metadata in endPoints.Metadata)
                {
                    Console.WriteLine($"Endpoint has metadata: {metadata}");
                }
                return next(httpContext);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/hello/{name:alpha}", async context =>
                {
                    var name = context.Request.RouteValues["name"];
                    await context.Response.WriteAsync($"hello{name}");
                });

                // Configure the Health Check endpoint and require an authorized user.
                endpoints.MapHealthChecks("/healthz");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/hello/{name:alpha}", async context =>
                {
                    var name = context.Request.RouteValues["name"];
                    await context.Response.WriteAsync($"hello{name}");
                });
            });
        }

        public static void HandRequestDel(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync($"This is a map middlerware");
            });
        }
    }
}
