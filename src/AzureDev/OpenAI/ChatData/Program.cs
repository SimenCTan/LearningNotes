using Azure;
using Azure.AI.OpenAI;
using System.Text.Json;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string azureOpenAIEndpoint = "https://marschat.openai.azure.com/";
string azureOpenAIKey = "46c3162e1a16499e9f2aa004ffe5d708";
string searchEndpoint = "https://marsai.search.windows.net";
string searchKey = "w4lmb3QZWNixj6Qs5jykSzRhnavivw6O1O4yEwxcV4AzSeBOxJOg";
string searchIndex = "contactindex";
string deploymentName = "gptturbo";
var client = new OpenAIClient(new Uri(azureOpenAIEndpoint), new AzureKeyCredential(azureOpenAIKey));
var chatCompletionsOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatRequestUserMessage("do you know Johnny")
    },
    AzureExtensionsOptions = new AzureChatExtensionsOptions()
    {
        Extensions = { new AzureCognitiveSearchChatExtensionConfiguration() {
            SearchEndpoint=new Uri(searchEndpoint),
            Key = searchKey,
            IndexName = searchIndex,
        }, }
    },
    DeploymentName = deploymentName,
};

Response<ChatCompletions> response = client.GetChatCompletions(chatCompletionsOptions);
ChatResponseMessage responseMessage = response.Value.Choices[0].Message;
Console.WriteLine($"Message from {responseMessage.Role}:");
Console.WriteLine("===");
Console.WriteLine(responseMessage.Content);
Console.WriteLine("===");
foreach (ChatResponseMessage contextMessage in responseMessage.AzureExtensionsContext.Messages)
{
    string contextContent = contextMessage.Content;
    try
    {
        var contextMessageJson = JsonDocument.Parse(contextMessage.Content);
        contextContent = JsonSerializer.Serialize(contextMessageJson, new JsonSerializerOptions()
        {
            WriteIndented = true,
        });
    }
    catch (JsonException)
    { }
    Console.WriteLine($"{contextMessage.Role}: {contextContent}");
}
Console.WriteLine("===");
