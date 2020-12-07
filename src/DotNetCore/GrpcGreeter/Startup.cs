using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GrpcGreeter
{
    public class Startup
    {
        private readonly SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Guid.NewGuid().ToByteArray());
        private readonly JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc(option=> {
                option.EnableDetailedErrors = true;
                option.MaxReceiveMessageSize = 10 * 1024 * 1024;
                option.MaxSendMessageSize = 2 * 1024 * 1024;
            });
            services.AddCors(option =>
            {
                option.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
                });
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, policy =>
                {
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireClaim(claimType: ClaimTypes.Name);
                });
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateActor = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        IssuerSigningKey = securityKey
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            // Must be added between UseRouting and UseEndpoints
            app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
            app.UseCors();

            // authorization and authentication
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GreeterService>().EnableGrpcWeb().RequireCors("AllowAll");

                endpoints.MapGet("/generateJwtToken", async context =>
                {
                    await context.Response.WriteAsync(GenerateJwtToken(context.Request.Query["name"]));
                });
            });
        }

        private string GenerateJwtToken(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidOperationException("Name is not specified.");
            }
            var claims = new[] { new Claim(ClaimTypes.Name, name) };
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken("ExampleServer", "ExampleClients", claims, expires: DateTime.Now.AddSeconds(60), signingCredentials: credentials);
            return tokenHandler.WriteToken(token);
        }
    }
}
