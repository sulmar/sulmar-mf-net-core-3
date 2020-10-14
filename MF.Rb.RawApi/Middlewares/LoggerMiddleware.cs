﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MF.Rb.RawApi.Middlewares
{
    
    // Klasa middleware (warstwa pośrednia)
    public class LoggerMiddleware
    {
        private readonly RequestDelegate next;
        public LoggerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Trace.WriteLine($"{context.Request.Method} {context.Request.Path}");

            await next(context);

            Trace.WriteLine($"{context.Response.StatusCode}");
        }

    }
}
