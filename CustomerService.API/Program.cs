using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using Serilog;
using Microsoft.Extensions.Configuration;

namespace CustomerService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            try
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();
                Log.Information("app starting");
                CreateHostBuilder(args).Build().Run();
                Log.Information("app terminated");
            }
            catch (Exception e)
            {
                Log.Fatal("app crashed", e);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .UseSerilog();
    }
}
