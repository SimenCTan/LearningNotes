using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Plugins.Core;
using PluginExamples.Plugins;

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
kernel.ImportPluginFromType<IngredientsPlugin>();

string prompt = @"This is a list of ingredients available to the user:
    {{IngredientsPlugin.GetIngredients}}

    Please suggest a recipe the user could make with
    some of the ingredients they have available";

var result = await kernel.InvokePromptAsync(prompt);
Console.WriteLine(result);

