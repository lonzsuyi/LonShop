using System.Reflection;
using Microsoft.EntityFrameworkCore;
using LonShop.BaseCore.Entities.BasketAggregate;
using LonShop.BaseCore.Entities.GoodAggregate;
using LonShop.BaseCore.Entities.DeliverAggregate;
using LonShop.BaseCore.Entities.CurrencyAggregate;
using LonShop.BaseCore.Entities.OrderAggregate;

namespace LonShop.Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}