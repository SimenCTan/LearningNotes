
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Planning;
using Microsoft.SemanticKernel.Plugins.MsGraph.Connectors.CredentialManagers;
using Microsoft.SemanticKernel.Plugins.OpenApi;
using Microsoft.SemanticKernel.Plugins.OpenApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();
var apikey = builder.Configuration["OpenAIKey"]?.ToString() ?? string.Empty;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion("gpt-3.5-turbo", apikey).Build();
// prefetch graph token
LocalUserMSALCredentialManager credentialManager = await LocalUserMSALCredentialManager.CreateAsync().ConfigureAwait(false);

// var token = await credentialManager.GetTokenAsync(
//     builder.Configuration["MSGraph:ClientId"],
//     builder.Configuration["MSGraph:TenantId"],
//     // API Manifest file captures required scopes. In the future, we have plans to improve integrations to automate this process
//     // so that you don't have to specify the scopes in your auth callback.
//     ["Mail.Read"],
//     new Uri(builder.Configuration["MSGraph:RedirectUri"])).ConfigureAwait(false);


var fakeToken = "EwB4A8l6BAAUbDba3x2OMJElkF7gJ4z/VbCPEz0AASzgJGy67s1XTtoVWoNh+b03M3Vn/mbNZNCIgNxAqTsekVFu33ULdDcoxi2uRJoSDxnIYZafESPN2o03uWvmzwe0PeaK+F7FhMGZYA0WAUFixjDJuXCAPfWe1iNEvshX6qkcggXo4ZBmWrJBNPgDUlC/Ae6bM1OE1LaaEQPBsOFrRr2X+3emGNWzK/dOveUsDlpvbhcPTJjFeJAunhrCumuo1KLMTwAs/MUYZ0W1cxqhV+y2AkQBu6Q0+wy9HqDiHSofjSHG8/OoZmEldDlVfKsiHDVLo3Pix+UpN+qGAabRdMgolGajc2tY0tVtrewXkIEC0fgu17MMWjKRcLlOKCEDZgAACJSw/IN03vHiSALjddZLmC36jFTHCqIKGZ46gR7IzLC74tvhZ/o9rI4G7fX43CaFovFkIK8Fc+/XsWMDiMzAK61RGi1z5oqrtj5GUCkn8qmdP2QdWXKlfCJ6DzhleHz2kKkjmLD9amDAjXr1ZK1SOTF3tO8+oqPnEUTdeTyAmfPQ9cZdYYEVYOXVRpjA+cCixlVxoh438lGHhR6RL/pPWsnaf4hNSExA+oRBwJK26N70aUid+cHEnEtN5kFUz+kgwAIgF0nssNHmaK9S7Ie0tXz+g3ErED9LeidvxXbU5vo1TLdZxT//aEqKgZ7vBQRX6vcbFbr6oaGUlpZwJBMQ13owsEftQbrNnvYdY6DFsWlLpwa4aOGx+nVoDsAQDn7junYtg0fZ2+x29aZp11Gs3wdoKGh2OoOBnv8R2A1vTHJ+NPKKwGvqiLZc8rTW2bx/tBYRubuf8plLC2EQeHTo4pnCed/VMkp3ZQgWog2YS6LUj4O5tXu3tcu52FteRCmxVO1aoO7phlfX/TVsUatttqtnzXXv0fqodXJjlNKM7Dn+jf6scApstQ9u6aZ5Pyd0eTLUaAiwqfzEsVmIpyRSqgG1au4osFJ572UTXlPPLzTNY1EL2cG30urZYPZoiUoLmiiHJUWaEmo/BwK3rSyP1PIqHZGacg0dpUgtHcCZJLNGbemDzU7b9jPdGIsMW1+k5WQdbNqnP5ZY8AINqFBqsHlsGAEpGLwaN6/AOWPjH3XKxPQt41JGfRNLWO3Ce7ZmM+F39Cidj2KzVTPGRTeKfMAUXIgC";
// create graph auth callback to inject auth header
AuthenticateRequestAsyncCallback? graphAuthCallback = (HttpRequestMessage requestMessage, CancellationToken _) =>
{
    requestMessage.Headers.Add("Authorization", $"Bearer {fakeToken}");
    return Task.CompletedTask;
};

// Microsoft Graph API execution parameters
var graphOpenApiFunctionExecutionParameters = new OpenApiFunctionExecutionParameters(
    authCallback: graphAuthCallback,
    serverUrlOverride: new Uri("https://graph.microsoft.com/v1.0"));

// specify auth callbacks for each API dependency
// we don't need one for GitHub as markdown API doesn't require any auth
var apiManifestPluginParameters = new ApiManifestPluginParameters
{
    FunctionExecutionParameters = new()
    {
        { "microsoft.graph", graphOpenApiFunctionExecutionParameters },
        // no need for github authentication as markdown API does not need it
    }
};

// import api manifest plugin
KernelPlugin plugin =
await kernel.ImportPluginFromApiManifestAsync(
    "MessageProcessorPlugin",                   // plugin name
    "MessageProcessorPlugin/apimanifest.json",  // path to api manifest file
    apiManifestPluginParameters)
    .ConfigureAwait(false);


// set goal
var goal = @"
Get my last email";

// create planner
var planner = new FunctionCallingStepwisePlanner(
    new FunctionCallingStepwisePlannerOptions
    {
        MaxIterations = 30,
        MaxTokens = 32000
    }
);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/Chat", async () =>
{
    // execute plan
    var result = await planner.ExecuteAsync(kernel, goal);
    return result;
}).WithName("graphchat").WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


