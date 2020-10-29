using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using TodoApi.DIServices;
using TodoApi.Middlewares;
using TodoApi.Models;

namespace TodoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
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
            services.Configure<PositionOptions>(Configuration.GetSection(PositionOptions.Position));

            // IConfigureNamedOptions
            services.Configure<TopItemSettings>(TopItemSettings.Month, Configuration.GetSection("TopItem:Month"));
            services.Configure<TopItemSettings>(TopItemSettings.Year, Configuration.GetSection("TopItem:Year"));

            // di config
            services.AddOptions<MyConfigOptions>()
                .Bind(Configuration.GetSection(MyConfigOptions.MyConfig))
                .ValidateDataAnnotations();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
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
