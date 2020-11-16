using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TodoApi.Filters
{
    public class MySampleActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something before the action executes.
            Debug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
            Debug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
        }
    }
}
