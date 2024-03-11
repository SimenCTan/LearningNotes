using System;
using System.Collections.Generic;
using Microsoft.Azure.CognitiveServices.Search.WebSearch;
using Microsoft.Azure.CognitiveServices.Search.WebSearch.Models;
using System.Linq;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
await BingSearch();

public partial class Program
{

    static async Task BingSearch()
    {
        var client = new WebSearchClient(new ApiKeyServiceClientCredentials("testkey"));

        await WebResults(client);
        // Search with count and offset...
        await WebResultsWithCountAndOffset(client);
        // Search with news filter...
        await WebSearchWithResponseFilter(client);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    public static async Task WebResults(WebSearchClient client)
    {
        try
        {
            var webData = await client.Web.SearchAsync(query: "Yosemite National Park");
            Console.WriteLine("Searching for \"Yosemite National Park\"");

            // Code for handling responses is provided in the next section...
            if (webData?.WebPages?.Value?.Count > 0)
            {
                // find the first web page
                var firstWebPagesResult = webData.WebPages.Value.FirstOrDefault();

                if (firstWebPagesResult != null)
                {
                    Console.WriteLine("Webpage Results # {0}", webData.WebPages.Value.Count);
                    Console.WriteLine("First web page name: {0} ", firstWebPagesResult.Name);
                    Console.WriteLine("First web page URL: {0} ", firstWebPagesResult.Url);
                }
                else
                {
                    Console.WriteLine("Didn't find any web pages...");
                }
            }
            else
            {
                Console.WriteLine("Didn't find any web pages...");
            }

            /*
             * Images
             * If the search response contains images, the first result's name
             * and url are printed.
             */
            if (webData?.Images?.Value?.Count > 0)
            {
                // find the first image result
                var firstImageResult = webData.Images.Value.FirstOrDefault();

                if (firstImageResult != null)
                {
                    Console.WriteLine("Image Results # {0}", webData.Images.Value.Count);
                    Console.WriteLine("First Image result name: {0} ", firstImageResult.Name);
                    Console.WriteLine("First Image result URL: {0} ", firstImageResult.ContentUrl);
                }
                else
                {
                    Console.WriteLine("Didn't find any images...");
                }
            }
            else
            {
                Console.WriteLine("Didn't find any images...");
            }

            /*
             * News
             * If the search response contains news articles, the first result's name
             * and url are printed.
             */
            if (webData?.News?.Value?.Count > 0)
            {
                // find the first news result
                var firstNewsResult = webData.News.Value.FirstOrDefault();

                if (firstNewsResult != null)
                {
                    Console.WriteLine("\r\nNews Results # {0}", webData.News.Value.Count);
                    Console.WriteLine("First news result name: {0} ", firstNewsResult.Name);
                    Console.WriteLine("First news result URL: {0} ", firstNewsResult.Url);
                }
                else
                {
                    Console.WriteLine("Didn't find any news articles...");
                }
            }
            else
            {
                Console.WriteLine("Didn't find any news articles...");
            }

            /*
             * Videos
             * If the search response contains videos, the first result's name
             * and url are printed.
             */
            if (webData?.Videos?.Value?.Count > 0)
            {
                // find the first video result
                var firstVideoResult = webData.Videos.Value.FirstOrDefault();

                if (firstVideoResult != null)
                {
                    Console.WriteLine("\r\nVideo Results # {0}", webData.Videos.Value.Count);
                    Console.WriteLine("First Video result name: {0} ", firstVideoResult.Name);
                    Console.WriteLine("First Video result URL: {0} ", firstVideoResult.ContentUrl);
                }
                else
                {
                    Console.WriteLine("Didn't find any videos...");
                }
            }
            else
            {
                Console.WriteLine("Didn't find any videos...");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("Encountered exception. " + ex.Message);
        }
    }

    public static async Task WebResultsWithCountAndOffset(WebSearchClient client)
    {
        try
        {
            var webData = await client.Web.SearchAsync(query: "Best restaurants in Seattle", offset: 10, count: 20);
            Console.WriteLine("\r\nSearching for \" Best restaurants in Seattle \"");

            if (webData?.WebPages?.Value?.Count > 0)
            {
                var firstWebPagesResult = webData.WebPages.Value.FirstOrDefault();

                if (firstWebPagesResult != null)
                {
                    Console.WriteLine("Web Results #{0}", webData.WebPages.Value.Count);
                    Console.WriteLine("First web page name: {0} ", firstWebPagesResult.Name);
                    Console.WriteLine("First web page URL: {0} ", firstWebPagesResult.Url);
                }
                else
                {
                    Console.WriteLine("Couldn't find first web result!");
                }
            }
            else
            {
                Console.WriteLine("Didn't see any Web data..");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Encountered exception. " + ex.Message);
        }
    }

    public static async Task WebSearchWithResponseFilter(WebSearchClient client)
    {
        try
        {
            IList<string> responseFilterstrings = new List<string>() { "news" };
            var webData = await client.Web.SearchAsync(query: "Microsoft", responseFilter: responseFilterstrings);
            Console.WriteLine("\r\nSearching for \" Microsoft \" with response filter \"news\"");

            if (webData?.News?.Value?.Count > 0)
            {
                var firstNewsResult = webData.News.Value.FirstOrDefault();

                if (firstNewsResult != null)
                {
                    Console.WriteLine("News Results #{0}", webData.News.Value.Count);
                    Console.WriteLine("First news result name: {0} ", firstNewsResult.Name);
                    Console.WriteLine("First news result URL: {0} ", firstNewsResult.Url);
                }
                else
                {
                    Console.WriteLine("Couldn't find first News results!");
                }
            }
            else
            {
                Console.WriteLine("Didn't see any News data..");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("Encountered exception. " + ex.Message);
        }
    }
}
