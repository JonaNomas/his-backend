using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace Sistema.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("###################################################");
            Console.WriteLine("#########            HIS 1.0            ##########");
            Console.WriteLine("###################################################");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}