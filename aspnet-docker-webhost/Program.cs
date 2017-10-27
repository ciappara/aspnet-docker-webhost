using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

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
    
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Starting up!");
                BuildWebHost(args).Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERR:" + ex.Message);
            }
        }

        //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/hosting?tabs=aspnetcore2x
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseUrls("http://*:36098")
                .UseStartup<Startup>()
                .Build();
    }
}

//https://github.com/aspnet/KestrelHttpServer/issues/639
//public static void Main(string[] args)
//{
//    var host = new WebHostBuilder()
//        .UseServer("Microsoft.AspNetCore.Server.Kestrel")
//        .UseApplicationBasePath(Directory.GetCurrentDirectory())
//        .UseDefaultConfiguration(args)
//        .UseIISPlatformHandlerUrl()
//        .UseStartup<Startup>()
//        .UseUrls("http://localhost:5050")
//        .Build();

//    host.Run();


//BuildWebHost(args).Run();

//var webHost = new WebHostBuilder()
//    //.UseShutdownTimeout(TimeSpan.FromMilliseconds(500))
//    .UseKestrel(SetServerOptions)
//    .UseContentRoot(Directory.GetCurrentDirectory())
//    .UseUrls("http://*:36098")
//    //.UseIISIntegration()
//    .UseStartup<Startup>()
//    .Build();

//}