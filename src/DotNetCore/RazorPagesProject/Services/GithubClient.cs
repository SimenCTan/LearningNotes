using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace RazorPagesProject.Services
{
    public class GithubClient : IGithubClient
    {
        public HttpClient Client { get; }
        public GithubClient(HttpClient httpClient)
        {
            Client = httpClient;
        }
        public async Task<GithubUser> GetUserAsync(string userName)
        {
            var response = await Client.GetAsync($"/users/{Uri.EscapeDataString(userName)}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<GithubUser>();
        }
    }
}
