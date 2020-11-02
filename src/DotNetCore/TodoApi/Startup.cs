using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using TodoApi.CustomLoggers;
using TodoApi.DIServices;
using TodoApi.Extensions;
using TodoApi.Middlewares;
using TodoApi.Models;
using TodoApi.Transformers;

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
            services.AddRouting(options =>
            {
                options.ConstraintMap["slugify"] = typeof(SlugifyParameterTransformer);
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

            //auth
            //services.AddAuthorization(option =>
            //{
            //    option.FallbackPolicy = new AuthorizationPolicyBuilder()
            //                    .RequireAuthenticatedUser()
            //                    .Build();
            //});

            services.AddDirectoryBrowser();

            // server add health check
            services.AddHealthChecks()
                .AddPrivateMemoryHealthCheck(1024L * 1024L * 256L);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,ILogger<Startup> logger,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/html";

                        await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
                        await context.Response.WriteAsync("ERROR!<br><br>\r\n");

                        var exceptionHandlerPathFeature =
                            context.Features.Get<IExceptionHandlerPathFeature>();

                        if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
                        {
                            await context.Response.WriteAsync("File error thrown!<br><br>\r\n");
                        }

                        await context.Response.WriteAsync("<a href=\"/\">Home</a><br>\r\n");
                        await context.Response.WriteAsync("</body></html>\r\n");
                        await context.Response.WriteAsync(new string(' ', 512)); // IE padding
                    });
                });
                app.UseHsts();
            }
            int count = 0;
            app.Use(next => async context =>
            {
                using (new MyStopwatch(logger, $"Time {++count}"))
                {
                    await next(context);
                }

            });

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
           
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "to do api");
            });
            app.UseRouting();
            var options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("mydefault.html");
            app.UseDefaultFiles(options);

            // Set up custom content types - associating file extension to MIME type
            var provider = new FileExtensionContentTypeProvider();
            // Add new mappings
            provider.Mappings[".myapp"] = "application/x-msdownload";
            provider.Mappings[".htm3"] = "text/html";
            provider.Mappings[".image"] = "image/png";
            // Replace an existing mapping
            provider.Mappings[".rtf"] = "application/x-msdownload";
            // Remove MP4 videos.
            provider.Mappings.Remove(".mp4");
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "MyStaticFiles")),
                RequestPath = "/staticfiles",
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={6000}");
                },
                ContentTypeProvider = provider
            });

            app.UseMiddleware<ProductsLinkMiddleware>();

            app.Use(next => async context =>
            {
                using (new MyStopwatch(logger, $"Time {++count}"))
                {
                    await next(context);
                }
            });

            app.UseAuthentication();
            app.UseAuthorization();

            
            app.Use(next => async context =>
            {
                using (new MyStopwatch(logger, $"Time {++count}"))
                {
                    await next(context);
                }
            });

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
