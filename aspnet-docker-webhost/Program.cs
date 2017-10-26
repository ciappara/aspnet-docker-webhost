﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace aspnet_docker_webhost
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger)
        {
            var applicationName = $"<tr><td>ApplicationName</td><td>{env.ApplicationName}</td></tr>";
            var contentRootPath = $"<tr><td>ContentRootPath</td><td>{env.ContentRootPath}</td></tr>";
            var contentRootFileProvider = $"<tr><td>ContentRootFileProvider</td><td>{env.ContentRootFileProvider}</td></tr>";
            var environmentName = $"<tr><td>EnvironmentName</td><td>{env.EnvironmentName}</td></tr>";
            var webRootPath = $"<tr><td>WebRootPath</td><td>{env.WebRootPath}</td></tr>";
            var webRootFileProvider = $"<tr><td>WebRootFileProvider</td><td>{env.WebRootFileProvider}</td></tr>";
            var content = $"<html><body><table><tbody><h1>Complete list of IHostingEnvironment properties</h1>{applicationName}{contentRootPath}{contentRootFileProvider}{environmentName}{webRootPath}{webRootFileProvider}</tbody></table></body></html>";

            app.Run(context =>
            {
                context.Response.ContentType = "text/html";
                return context.Response.WriteAsync(content);
            });
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var webHost = new WebHostBuilder()
                .UseShutdownTimeout(TimeSpan.FromMilliseconds(500))
                .UseKestrel(SetServerOptions)
                .UseStartup<Startup>()
                .Build();

            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Starting up!");
                webHost.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERR:" + ex.Message);
            }
        }
        
        private static void SetServerOptions(KestrelServerOptions options)
        {
            options.Listen(IPAddress.Loopback, 36098, listenOptions =>
            {
            });
        }
    }
}
