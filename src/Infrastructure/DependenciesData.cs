using LonShop.Infrastructure.Data;
using LonShop.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LonShop.Infrastructure;

public static class DependenciesData
{
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        var useOnlyInMemoryDatabase = false;

        if (configuration["UseOnlyInMemoryDatabase"] != null)
        {
            useOnlyInMemoryDatabase = bool.Parse(configuration["UseOnlyInMemoryDatabase"]);
        }

        if (useOnlyInMemoryDatabase)
        {
            services.AddDbContext<StoreContext>(c =>
               c.UseInMemoryDatabase("ShopStore"));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseInMemoryDatabase("Identity"));
        }
        else
        {
            // use real database
            services.AddDbContext<StoreContext>(c =>
                c.UseSqlServer(configuration.GetConnectionString("ShopStoreConnection")));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));
        }
    }
}