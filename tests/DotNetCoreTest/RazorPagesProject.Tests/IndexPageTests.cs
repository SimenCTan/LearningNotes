using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using RazorPagesProject;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using RazorPagesProject.Tests.Helpers;
using AngleSharp.Html.Dom;
using System.Net;
using Microsoft.Extensions.Logging;
using RazorPagesProject.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.TestHost;
using RazorPagesProject.Services;

namespace RazorPagesProject.Tests
{
    public class IndexPageTests:IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public IndexPageTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task Post_DeleteAllMessagesHandler_ReturnsRedirectToRoot()
        {
            // arrange
            var defaultPage = await _client.GetAsync("/");
            var content = await HtmlHelpers.GetDocumentAsync(defaultPage);

            // act
            var response = await _client.SendAsync((IHtmlFormElement)content.QuerySelector("form[id='messages']"),
                                (IHtmlButtonElement)content.QuerySelector("button[id='deleteAllBtn']"));

            // Assert
            Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("/", response.Headers.Location.OriginalString);
        }

        [Fact]
        public async Task Post_DeleteMessageHandler_ReturnsRedirectToRoot()
        {
            // Arrange
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var serviceProvider = services.BuildServiceProvider();

                    using (var scope = serviceProvider.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices
                            .GetRequiredService<AppDbContext>();
                        var logger = scopedServices
                            .GetRequiredService<ILogger<IndexPageTests>>();

                        try
                        {
                            Utilities.ReinitializeDbForTests(db);
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "An error occurred seeding " +
                                "the database with test messages. Error: {Message}",
                                ex.Message);
                        }
                    }
                });
            })
                .CreateClient(new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });
            var defaultPage = await client.GetAsync("/");
            var content = await HtmlHelpers.GetDocumentAsync(defaultPage);

            //Act
            var response = await client.SendAsync(
                (IHtmlFormElement)content.QuerySelector("form[id='messages']"),
                (IHtmlButtonElement)content.QuerySelector("form[id='messages']")
                    .QuerySelector("div[class='panel-body']")
                    .QuerySelector("button"));

            // Assert
            Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("/", response.Headers.Location.OriginalString);
        }

        [Fact]
        public async Task Post_AddMessageHandler_ReturnsSuccess_WhenMissingMessageText()
        {
            // Arrange
            var defaultPage = await _client.GetAsync("/");
            var content = await HtmlHelpers.GetDocumentAsync(defaultPage);
            var messageText = string.Empty;

            // Act
            var response = await _client.SendAsync(
                (IHtmlFormElement)content.QuerySelector("form[id='addMessage']"),
                (IHtmlButtonElement)content.QuerySelector("button[id='addMessageBtn']"),
                new Dictionary<string, string>
                {
                    ["Message.Text"] = messageText
                });

            // Assert
            Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
            // A ModelState failure returns to Page (200-OK) and doesn't redirect.
            response.EnsureSuccessStatusCode();
            Assert.Null(response.Headers.Location?.OriginalString);
        }

        [Fact]
        public async Task Post_AnalyzeMessagesHandler_ReturnsRedirectToRoot()
        {
            // Arrange
            var defaultPage = await _client.GetAsync("/");
            var content = await HtmlHelpers.GetDocumentAsync(defaultPage);

            //Act
            var response = await _client.SendAsync(
                (IHtmlFormElement)content.QuerySelector("form[id='analyze']"),
                (IHtmlButtonElement)content.QuerySelector("button[id='analyzeBtn']"));

            // Assert
            Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("/", response.Headers.Location.OriginalString);
        }

        public class TestQuoteService : IQuoteService
        {
            public Task<string> GenerateQuote()
            {
                return Task.FromResult<string>(
                    "Something's interfering with time, Mr. Scarman, " +
                    "and time is my business.");
            }
        }

        [Fact]
        public async Task Get_QuoteService_ProvidesQuoteInPage()
        {
            // Arrange
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<IQuoteService, TestQuoteService>();
                });
            })
                .CreateClient();

            //Act
            var defaultPage = await client.GetAsync("/");
            var content = await HtmlHelpers.GetDocumentAsync(defaultPage);
            var quoteElement = content.QuerySelector("#quote");

            // Assert
            Assert.Equal("Something's interfering with time, Mr. Scarman, " +
                "and time is my business.", quoteElement.Attributes["value"].Value);
        }
    }
}
