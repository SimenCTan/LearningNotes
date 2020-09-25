﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Middlewares
{
    public class RequestSetOptionsStartUpFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                builder.UseMiddleware<RequestSetOptionsMiddleware>();
                next(builder);
            };
        }
    }
}
