using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Filters
{
    public class SampleAsyncPageFilter : IAsyncPageFilter
    {
        private readonly IConfiguration _configuration;
        public SampleAsyncPageFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            var key = _configuration["UserAgentID"];
            context.HttpContext.Request.Headers.TryGetValue("user-agent",
                                                            out StringValues value);
            // to do filter

            return Task.CompletedTask;
        }

        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
                                                      PageHandlerExecutionDelegate next)
        {
            // Do post work.
            await next.Invoke();
        }
    }
}
