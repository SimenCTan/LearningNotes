using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace PluginExamples.Plugins;

public class IngredientsPlugin
{
    [KernelFunction, Description("Get a list of the user's ingredients")]
    public static string GetIngredients()
    {
        string dir = Directory.GetCurrentDirectory();
        string content = File.ReadAllText($"{dir}/ingredients.txt");
        return content;
    }
}
