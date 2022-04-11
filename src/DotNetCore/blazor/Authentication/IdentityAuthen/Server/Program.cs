using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using IdentityAuthen.Server.Data;
using IdentityAuthen.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options => {
        // Clients
        var spaClient = ClientBuilder
            .SPA("IdentityAuthen.Client")
            .WithRedirectUri("https://localhost:7276/authentication/login-callback")
            .WithLogoutRedirectUri("https://localhost:7276/authentication/logged-out")
            .Build();
        spaClient.AllowedCorsOrigins = new[]
        {
            "https://localhost:7276"
        };

        options.Clients.Add(spaClient);
    });

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
// Allow requests from the external ManufacturingHub and  MissionControl applications
app.UseCors(cors => cors.WithOrigins("https://localhost:7276").AllowAnyMethod().AllowAnyHeader().AllowCredentials());

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
