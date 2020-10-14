using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MF.Rb.RawApi.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;

namespace MF.Rb.RawApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Logowanie komunikatów (middleware)
            //app.Use(async (context, next) =>
            //{
            //    Trace.WriteLine($"{context.Request.Method} {context.Request.Path}");

            //    await next();

            //    Trace.WriteLine($"{context.Response.StatusCode}");
            //});


            app.UseMiddleware<LoggerMiddleware>();


            // Autoryzacja (middleware)
            app.Use(async (context, next) =>
            {
                if (context.Request.Headers.ContainsKey("Authorization"))
                {
                    await next();
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                }

            });


            // Wersjonowanie (middleware)
            app.Use(async (context, next) =>
            {
                if (context.Request.Headers.TryGetValue("api-version", out StringValues values))
                {
                    string version = values.First();

                    if (version == "v1")
                    {
                        context.Response.StatusCode = StatusCodes.Status406NotAcceptable;

                    }
                    else
                    {
                        context.Request.Path = $"{context.Request.Path}{version}";

                        await next();
                    }
                }
                else
                {
                    await next();
                }
            });

            app.Run(context => context.Response.WriteAsync("Hello World!"));
        }
    }
}
