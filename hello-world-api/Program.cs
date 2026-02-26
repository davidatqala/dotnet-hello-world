using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace hello_world_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dir = Directory.GetCurrentDirectory();
            while (dir != null && Directory.GetFiles(dir, "*.sln").Length == 0)
                dir = Directory.GetParent(dir)?.FullName;

            var outputPath = Path.Combine(dir ?? Directory.GetCurrentDirectory(), "helloworld.txt");
            File.WriteAllText(outputPath, "Hello world!");

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
