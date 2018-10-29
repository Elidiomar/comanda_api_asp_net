using System;
using System.IO;
using Comanda.Infra.Cross.Identity.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Comanda.Service.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            var contentRoot = Directory.GetCurrentDirectory();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {

                    var context = services.GetRequiredService<ApplicationDbContext>();
                    //Configurations.Initialize(context);

                    var config = new ConfigurationBuilder()
                    .SetBasePath(contentRoot)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                    //// Requires using RazorPagesMovie.Models;                    
                    //// apply migration
                    // SampleDataProvider.ApplyMigration(services);

                    //// seed default data
                    //SampleDataProvider.Seed(services, config);

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
