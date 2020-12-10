using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesProject.Services
{
    public interface IGithubClient
    {
        Task<GithubUser> GetUserAsync(string userName);
    }
}
