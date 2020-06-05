using IllyriadAssist.Data;
using IllyriadAssist.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.EntityFrameworkCore.Update.Internal;
using SQLitePCL;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;

namespace IllyriadAssist
{
    public class Program
    {

        public static void Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();

            Console.WriteLine("--------------------------------Running Migration Scripts--------------------------------------------------");

            CreateDbTablesIfNotExist(host);

            Console.WriteLine("-------------------------------Make Sure Database is Seeded------------------------------------------------");

            CreateDbIfNotExists(host);

            Console.WriteLine("---------------------------------Begining to Load Browser--------------------------------------------------");
            //System.Threading.Thread.Sleep(30000);
            LoadDefaultBrowser("http://localhost:5001");

            Console.WriteLine("--------------------------------------Starting Host--------------------------------------------------------");

            host.Run();

            Console.WriteLine("----------------Application Startup Complete.  Open a web browser and type in localhost:5001---------------");

        }

        private static void LoadDefaultBrowser(string localURL)
        {

            using (var proc = new System.Diagnostics.Process())
            {
                proc.StartInfo.FileName = localURL;
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Verb = "open";
                proc.Start();
            }

        }
        
        private static void CreateDbTablesIfNotExist(IHost host)
        {

            using (var scope = host.Services.CreateScope())
            {

                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<IllyContext>();

                context.Database.Migrate();

            }

        }
        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {

                    var context = services.GetRequiredService<IllyContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {

                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
