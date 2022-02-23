using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LonShop.BaseCore.Interfaces;
using LonShop.BaseCore.Services;
using LonShop.Infrastructure.Data;
using LonShop.Infrastructure.Logging;


namespace LonShop.LonShopWeb.Configuration
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddBaseCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Basic service
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            // Custom service
            services.AddScoped<IGoodService, GoodService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IDeliverService, DeliverService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}