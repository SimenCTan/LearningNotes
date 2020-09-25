using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TodoApi.Middlewares
{
    public class RequestSetOptionsMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestSetOptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext,
            ILogger<RequestSetOptionsMiddleware> logger)
        {
            var option = httpContext.Request.Query["option"];
            logger.LogInformation("test");
            if (!string.IsNullOrEmpty(option))
            {
                httpContext.Items["option"] = WebUtility.HtmlEncode(option);
            }
            await _next(httpContext);
        }
    }
}
