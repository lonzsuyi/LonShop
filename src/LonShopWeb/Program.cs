using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using LonShop.BaseCore.Entities.UserAggregate;
using LonShop.Infrastructure.Data;
using LonShop.Infrastructure.Identity;

namespace LonShopWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args);

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var scopedProvider = scope.ServiceProvider;
                var loggerFactory = scopedProvider.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger<Program>();
                try
                {
                    // identity
                    var userManager = scopedProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = scopedProvider.GetRequiredService<RoleManager<ApplicationRole>>();
                    AppIdentityDbContextSeed.SeedAsync(userManager, roleManager).Wait();

                    // store
                    var storeContext = scopedProvider.GetRequiredService<StoreContext>();
                    StoreContextSeed.SeedAsync(storeContext, logger).Wait();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
