using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using IdentityAuthen.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var backendOrigin = "https://localhost:7275";

builder.Services.AddHttpClient("IdentityAuthen.ServerAPI", client => client.BaseAddress = new Uri(backendOrigin))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("IdentityAuthen.ServerAPI"));

builder.Services.AddApiAuthorization(c=>c.ProviderOptions.ConfigurationEndpoint=$"{backendOrigin}/_configuration/IdentityAuthen.Client");

await builder.Build().RunAsync();
