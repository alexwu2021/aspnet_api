using System;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using aspnetapp.DataAccessLayer.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace aspnetapp
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using(var scope = host.Services.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetService<PatientDbContext>();
                    // dbContext.Database.EnsureDeleted();
                    dbContext.Database.Migrate();
                    dbContext.Database.EnsureCreated();
                    Console.WriteLine("number of seeded patients: " + dbContext.Patients.Count());
                }
                catch(Exception e)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "Database Migration Error!");
                }
            }

            host.Run();
        }
   

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}