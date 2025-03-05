using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.AzureAISearch;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Memory;
using Microsoft.SemanticKernel.Plugins.Core;
using Microsoft.SemanticKernel.Plugins.Memory;

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
var apikey = config["OpenAIKey"]?.ToString() ?? string.Empty;
var azureSearchKey = config["AzureSearchKey"]?.ToString() ?? string.Empty;

var memoryBuilder = new MemoryBuilder();
memoryBuilder.WithOpenAITextEmbeddingGeneration("text-embedding-ada-002", apikey);
var acsMemoryStore = new AzureAISearchMemoryStore("host-service", azureSearchKey);
memoryBuilder.WithMemoryStore(acsMemoryStore);
var memory = memoryBuilder.Build();


const string MemoryCollectionName = "sktest";
var isCollectionExist = await acsMemoryStore.DoesCollectionExistAsync(MemoryCollectionName);
if (!isCollectionExist)
{
    await acsMemoryStore.CreateCollectionAsync(MemoryCollectionName);
}
await memory.SaveInformationAsync(MemoryCollectionName, id: "info1", text: "My name is Andrea");
await memory.SaveInformationAsync(MemoryCollectionName, id: "info2", text: "I currently work as a tourist operator");
await memory.SaveInformationAsync(MemoryCollectionName, id: "info3", text: "I currently live in Seattle and have been living there since 2005");
await memory.SaveInformationAsync(MemoryCollectionName, id: "info4", text: "I visited France and Italy five times since 2015");
await memory.SaveInformationAsync(MemoryCollectionName, id: "info5", text: "My family is from New York");
var questions = new[]
{
    "what is my name?",
    "where do I live?",
    "where is my family from?",
    "where have I traveled?",
    "what do I do for work?",
};

foreach (var question in questions)
{
    Console.WriteLine($"Question: {question}");
    var response = await memory.SearchAsync(MemoryCollectionName, question, limit: 1).FirstOrDefaultAsync();
    if (response != null)
    {
        Console.WriteLine($"Answer: {response.Metadata.Text}");
        Console.WriteLine($"Relevance: {response.Relevance}");
    }
    else
    {
        Console.WriteLine("Answer: I don't know");
    }
    Console.WriteLine();
}
