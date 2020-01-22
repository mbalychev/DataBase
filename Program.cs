using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PcRepaire.Data;

namespace PcRepaire
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();

                try
                { 
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    if (DbInitializer.DbInitializerStart(context))
                    {
                        logger.LogInformation("DataBase Loaded done");
                    }
                    else
                    {
                        logger.LogError("DataBase load error");
                    }
                }
                catch (Exception ex)
                { 
                    logger.LogError(ex, "An error occurred while seeding the database."); 
                }
            }

            host.Run();
            //CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();



    }
}
