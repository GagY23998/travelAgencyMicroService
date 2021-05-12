using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using TravelAgency.BookingService.Helpers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TravelAgency.BookingService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().
                         Enrich.FromLogContext().
                         WriteTo.Console().CreateLogger();

            CreateHostBuilder(args).Build().SeedDB().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
