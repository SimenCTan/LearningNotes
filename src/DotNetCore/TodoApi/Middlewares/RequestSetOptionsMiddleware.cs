using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;
using TodoApi.DIServices;

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
            ILogger<RequestSetOptionsMiddleware> logger,
            IOperationTransien operationTransien,
            IOperationScope operationScope,
            IOperationSingleton operationSingleton)
        {
            var option = httpContext.Request.Query["option"];
            logger.LogInformation($"transient id is {operationTransien.OperationId}");
            logger.LogInformation($"scope id is {operationScope.OperationId}");
            logger.LogInformation($"singleton id is {operationSingleton.OperationId}");
            if (!string.IsNullOrEmpty(option))
            {
                httpContext.Items["option"] = WebUtility.HtmlEncode(option);
            }
            await _next(httpContext);
        }
    }
}
