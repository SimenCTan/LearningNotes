using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace PluginExamples.Plugins;


public class MusicConcertPlugin
{
    [KernelFunction, Description("Get a list of upcoming concerts")]
    public static string GetTours()
    {
        string dir = Directory.GetCurrentDirectory();
        string content = File.ReadAllText($"{dir}/concertdates.txt");
        return content;
    }
}
