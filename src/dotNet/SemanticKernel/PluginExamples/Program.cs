using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Planning.Handlebars;
using Microsoft.SemanticKernel.Plugins.Core;
using Microsoft.SemanticKernel.PromptTemplates.Handlebars;
using PluginExamples.Plugins;
using PluginExamples.Plugins.ConvertCurrency;

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
var apikey = config["OpenAIKey"]?.ToString() ?? string.Empty;
var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion("gpt-3.5-turbo", apikey);
builder.Plugins.AddFromType<ConversationSummaryPlugin>();
var kernel = builder.Build();

// string history = @"In the heart of my bustling kitchen, I have embraced
//     the challenge of satisfying my family's diverse taste buds and
//     navigating their unique tastes. With a mix of picky eaters and
//     allergies, my culinary journey revolves around exploring a plethora
//     of vegetarian recipes.

//     One of my kids is a picky eater with an aversion to anything green,
//     while another has a peanut allergy that adds an extra layer of complexity
//     to meal planning. Armed with creativity and a passion for wholesome
//     cooking, I've embarked on a flavorful adventure, discovering plant-based
//     dishes that not only please the picky palates but are also heathy and
//     delicious.";

// string functionPrompt = @"User background:
//     {{ConversationSummaryPlugin.SummarizeConversation $history}}
//     Given this user's background, provide a list of relevant recipes.";
// var suggestRecipes = kernel.CreateFunctionFromPrompt(functionPrompt);

// var result = await kernel.InvokeAsync(
//     "ConversationSummaryPlugin",
//     "SummarizeConversation",
//     new() { { "input", input } });

// var result = await kernel.InvokeAsync(suggestRecipes, new KernelArguments {
//     { "history",history }
//  });


// string language = "Chinese";
// string history = @"I'm traveling with my kids and one of them
//    has a peanut allergy.";
// Assign a persona to the prompt
// string prompt = @$"
//     You are a travel assistant. You are helpful, creative,
//     and very friendly. Consider the traveler's background:
//     ${history}

//     Create a list of helpful phrases and words in
//     ${language} a traveler would find useful.

//     Group phrases by category. Include common direction
//     words. Display the phrases in the following format:
//     Hello - Ciao [chow]

//     Begin with: 'Here are some phrases in ${language}
//     you may find helpful:'
//     and end with: 'I hope this helps you on your trip!'";
// var result = await kernel.InvokePromptAsync(prompt);

// var prompts = kernel.CreatePluginFromPromptDirectory("Prompts/TravelPlugins");
// ChatHistory history = [];
// string input = @"I'm planning an anniversary trip with my
//     spouse. We like hiking, mountains, and beaches. Our
//     travel budget is $15000";
// var result = await kernel.InvokeAsync<string>(prompts["SuggestDestinations"], new() { { "input", input } });
// Console.WriteLine(result);
// history.AddUserMessage(input);
// history.AddAssistantMessage(result??string.Empty);

// Console.WriteLine("Where would you like to go?");
// input = Console.ReadLine();

// result = await kernel.InvokeAsync<string>(prompts["SuggestActivities"],
//     new() {
//         { "history", history },
//         { "destination", input },
//     }
// );

// to do plugin
// kernel.ImportPluginFromType<TodoListPlugin>();
// var result = await kernel.InvokeAsync<string>(
//     "TodoListPlugin",
//     "CompleteTask",
//     new() { { "task", "Buy groceries" } }
// );

// music plugin
// kernel.ImportPluginFromType<MusicLibrary>();
// string prompt = @"This is a list of music available to the user:
//     {{MusicLibrary.GetMusicLibrary}}

//     This is a list of music the user has recently played:
//     {{MusicLibrary.GetRecentPlays}}

//     Based on their recently played music, suggest a song from
//     the list to play next";

// var result = await kernel.InvokePromptAsync(prompt);

// recipe plugin
// kernel.ImportPluginFromType<IngredientsPlugin>();

// string prompt = @"This is a list of ingredients available to the user:
//     {{IngredientsPlugin.GetIngredients}}

//     Please suggest a recipe the user could make with
//     some of the ingredients they have available";

// var result = await kernel.InvokePromptAsync(prompt);

// create a planner
// kernel.ImportPluginFromType<MusicConcertPlugin>();
// kernel.ImportPluginFromType<MusicLibrary>();
// kernel.ImportPluginFromPromptDirectory("Prompts");
// var planner = new HandlebarsPlanner(new HandlebarsPlannerOptions { AllowLoops = true });
// string location = "Redmond WA USA";
// string goal = @$"Based on the user's recently played music, suggest a
//     concert for the user living in ${location}";

// var plan = await planner.CreatePlanAsync(kernel, goal);
// //var result = await plan.InvokeAsync(kernel);
// Console.WriteLine(plan);

// planner template
// var planner = new HandlebarsPlanner(new HandlebarsPlannerOptions { AllowLoops = true });
// var songSuggesterFunction = kernel.CreateFunctionFromPrompt(
//     promptTemplate: @"Based on the user's recently played music:
//         {{$recentlyPlayedSongs}}
//         recommend a song to the user from the music library:
//         {{$musicLibrary}}",
//     functionName: "SuggestSong",
//     description: "Suggest a song to the user"
// );
// kernel.Plugins.AddFromFunctions("SuggestSongPlugin", [songSuggesterFunction]);
// var songSuggestPlan = await planner.CreatePlanAsync(kernel, @"Suggest a song from the
//     music library to the user based on their recently played songs");
// Console.WriteLine("Song Plan:");
// Console.WriteLine(songSuggestPlan);

// kernel.ImportPluginFromType<MusicLibrary>();
// kernel.ImportPluginFromType<MusicConcertPlugin>();
// kernel.ImportPluginFromPromptDirectory("Prompts");

// var songSuggesterFunction = kernel.CreateFunctionFromPrompt(
//     promptTemplate: @"Based on the user's recently played music:
//     {{$recentlyPlayedSongs}}
//     recommend a song to the user from the music library:
//     {{$musicLibrary}}",
//     functionName: "SuggestSong",
//     description: "Suggest a song to the user"
// );

// kernel.Plugins.AddFromFunctions("SuggestSongPlugin", [songSuggesterFunction]);
// string dir = Directory.GetCurrentDirectory();
// string template = File.ReadAllText($"{dir}/handlebarsTemplate.txt");

// var handlebarsPromptFunction = kernel.CreateFunctionFromPrompt(
//     new()
//     {
//         Template = template,
//         TemplateFormat = "handlebars"
//     }, new HandlebarsPromptTemplateFactory()
// );

// string location = "Redmond WA USA";
// var templateResult = await kernel.InvokeAsync(handlebarsPromptFunction,
//     new() {
//         { "location", location },
//         { "suggestConcert", true }
//     });

// Console.WriteLine(templateResult);

// kernel.ImportPluginFromType<MusicLibrary>();
// kernel.ImportPluginFromType<MusicConcertPlugin>();
// kernel.ImportPluginFromPromptDirectory("Prompts");
// OpenAIPromptExecutionSettings settings = new()
// {
//     ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
// };
// string prompt = @"I live in Portland OR USA. Based on my recently
//     played songs and a list of upcoming concerts, which concert
//     do you recommend?";
// var result = await kernel.InvokePromptAsync(prompt, new(settings));
// Console.WriteLine(result);

// agent
// kernel.ImportPluginFromType<CurrencyConverter>();
// var prompts = kernel.ImportPluginFromPromptDirectory("Prompts");

// var result = await kernel.InvokeAsync(prompts["GetTargetCurrencies"],
//     new() {
//         {"input", "How many Australian Dollars is 140,000 Korean Won worth?"}
//     }
// );

// Console.WriteLine(result);

// Note: ChatHistory isn't working correctly as of SemanticKernel v 1.4.0

kernel.ImportPluginFromType<CurrencyConverter>();
var prompts = kernel.ImportPluginFromPromptDirectory("Prompts");
StringBuilder chatHistory = new();

OpenAIPromptExecutionSettings settings = new()
{
    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
};
string input;

do
{
    Console.WriteLine("What would you like to do?");
    input = Console.ReadLine()!;

    var intent = await kernel.InvokeAsync<string>(
        prompts["GetIntent"],
        new() { { "input", input } }
    );

    switch (intent)
    {
        case "ConvertCurrency":
            var currencyText = await kernel.InvokeAsync<string>(
                prompts["GetTargetCurrencies"],
                new() { { "input", input } }
            );

            var currencyInfo = currencyText!.Split("|");
            var result = await kernel.InvokeAsync("CurrencyConverter",
                "ConvertAmount",
                new() {
                    {"targetCurrencyCode", currencyInfo[0]},
                    {"baseCurrencyCode", currencyInfo[1]},
                    {"amount", currencyInfo[2]},
                }
            );
            Console.WriteLine(result);
            break;
        case "SuggestDestinations":
            chatHistory.AppendLine("User:" + input);
            var recommendations = await kernel.InvokePromptAsync(input!);
            Console.WriteLine(recommendations);
            break;
        case "SuggestActivities":

            var chatSummary = await kernel.InvokeAsync(
                "ConversationSummaryPlugin",
                "SummarizeConversation",
                new() { { "input", chatHistory.ToString() } });

            var activities = await kernel.InvokePromptAsync(
                input!,
                new() {
                    {"input", input},
                    {"history", chatSummary},
                    {"ToolCallBehavior", ToolCallBehavior.AutoInvokeKernelFunctions}
            });

            chatHistory.AppendLine("User:" + input);
            chatHistory.AppendLine("Assistant:" + activities.ToString());

            Console.WriteLine(activities);
            break;
        case "HelpfulPhrases":
        case "Translate":
            var autoInvokeResult = await kernel.InvokePromptAsync(input, new(settings));
            Console.WriteLine(autoInvokeResult);
            break;
        default:
            Console.WriteLine("Sure, I can help with that.");
            var otherIntentResult = await kernel.InvokePromptAsync(input);
            Console.WriteLine(otherIntentResult);
            break;
    }
}
while (!string.IsNullOrWhiteSpace(input));
