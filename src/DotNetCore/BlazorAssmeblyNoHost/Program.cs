using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorAssmeblyNoHost;
using Microsoft.Extensions.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var http = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
builder.Services.AddScoped(sp => http);
using var response = await http.GetAsync("car.json");
using var stream = await response.Content.ReadAsStreamAsync();
builder.Configuration.AddJsonStream(stream);
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
await builder.Build().RunAsync();
