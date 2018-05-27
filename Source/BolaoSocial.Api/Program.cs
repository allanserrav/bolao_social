using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BolaoSocial.Shared.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BolaoSocial.Api
{
    public class Program
    {
        // For async main
        // https://stackoverflow.com/questions/38114553/are-async-console-applications-supported-in-net-core/38127525

        public static async Task Main(string[] args) => await BuildWebHost(args).RunAsync();

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
