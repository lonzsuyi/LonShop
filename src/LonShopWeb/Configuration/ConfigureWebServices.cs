using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LonShop.LonShopWeb.Interfaces;
using LonShop.LonShopWeb.Services;

namespace LonShop.LonShopWeb.Configuration
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBasketViewModelService, BasketViewModelService>();

            return services;
        }
    }
}