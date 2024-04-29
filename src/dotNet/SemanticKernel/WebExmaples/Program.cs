using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Plugins.Core;
using Microsoft.SemanticKernel.Plugins.Web;
using Microsoft.SemanticKernel.Plugins.Web.Bing;

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
var apikey = config["OpenAIKey"]?.ToString() ?? string.Empty;
var bingKey = config["BingKey"]?.ToString() ?? string.Empty;

var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion("gpt-3.5-turbo", apikey);
builder.Plugins.AddFromType<ConversationSummaryPlugin>();
var kernel = builder.Build();

var bingConnector = new BingConnector(bingKey);
kernel.ImportPluginFromObject(new WebSearchEnginePlugin(bingConnector), "bing");
var question = "what is latest eth price";
var function = kernel.Plugins["bing"]["search"];
var bingResult = await kernel.InvokeAsync(function, new() { ["query"] = question });
Console.WriteLine(question);
Console.WriteLine("----");
Console.WriteLine(bingResult);
Console.WriteLine();
