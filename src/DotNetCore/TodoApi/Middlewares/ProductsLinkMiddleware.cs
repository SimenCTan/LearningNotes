using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Middlewares
{
    public class ProductsLinkMiddleware
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly RequestDelegate _next;

        public ProductsLinkMiddleware(RequestDelegate next, LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var url = _linkGenerator.GetPathByAction("ListProducts", "Store");

            await _next(httpContext);
        }
    }
}
