using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using LonShop.BaseCore.Entities.GoodAggregate;
using LonShop.BaseCore.Entities.DeliverAggregate;
using LonShop.BaseCore.Entities.CurrencyAggregate;

namespace LonShop.Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext storeContext, ILogger logger, int retry = 0)
        {
            var retryForAvailability = retry;

            try
            {
                if (storeContext.Database.IsSqlServer())
                {
                    storeContext.Database.Migrate();
                }

                if (!await storeContext.Goods.AnyAsync())
                {
                    await storeContext.Goods.AddRangeAsync(
                        GetGoods()
                    );

                    await storeContext.SaveChangesAsync();
                }

                if (!await storeContext.Currencies.AnyAsync())
                {
                    await storeContext.Currencies.AddRangeAsync(
                        GetCurrencies()
                    );

                    await storeContext.SaveChangesAsync();
                }

                if (!await storeContext.Costs.AnyAsync())
                {
                    await storeContext.Costs.AddRangeAsync(
                        GetCosts()
                    );

                    await storeContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;

                retryForAvailability++;

                logger.LogError(ex.Message);
                await SeedAsync(storeContext, logger, retryForAvailability);
                throw;
            }
        }

        static IEnumerable<Good> GetGoods()
        {
            return new List<Good>
            {
                new("Schweppes Lemonade Multipack Mini Cans 200mL",
                    "https://shop.coles.com.au/wcsstore/Coles-CAS/images/2/0/0/2007510.jpg",
                    "With a harmonious blend of lemon and lime oils, Schweppes Lemonade 200mL delivers",
                    6.18M,
                    "AUD"),
                new("Arnott's Original Salada250g on special",
                    "https://shop.coles.com.au/wcsstore/Coles-CAS/images/3/2/9/329800.jpg",
                    "Arnott's Salada Original crackers are a versatile crispbread for a quick snack or meal.",
                    2.50M,
                    "AUD"),
                new("Yoplait Petit Miam Squeezie Strawberry Yoghurt Pouch",
                    "https://shop.coles.com.au/wcsstore/Coles-CAS/images/6/5/6/6569239.jpg",
                    "Yoplait is one of the leading yoghurt brands in Australia.",
                    0.80M,
                    "AUD"),
                new("Kellogg's Coco Pops Chocolatey Breakfast Cereal",
                    "https://shop.coles.com.au/wcsstore/Coles-CAS/images/8/4/9/8490209.jpg",
                    "Kellogg's Coco Pops is the tasty chocolatey breakfast cereal treat that families have loved for generations.",
                    2.70M,
                    "AUD"),
                new("Coles Beef Sizzle Steak",
                    "https://shop.coles.com.au/wcsstore/Coles-CAS/images/1/8/3/1832188.jpg",
                    "Sourced from the top of the hind leg, sizzle steaks are quick and easy to cook. ",
                    10.00M,
                    "AUD"),
                new("Gatorade Lemon Lime Sports Drink",
                    "https://shop.coles.com.au/wcsstore/Coles-CAS/images/5/4/6/5468870.jpg",
                     "Gatorade Lemon Lime electrolyte sports drink contains critical electrolytes to help replace what’s lost in sweat and fuel you to perform at your best.",
                    1.90M,
                    "AUD"),
                new("Morning Fresh Raspberry & Crisp Apple Dishwashing Liquid",
                    "https://shop.coles.com.au/wcsstore/Coles-CAS/images/3/2/0/3208890.jpg",
                    "Morning Fresh Australia's #1 dishwashing liquid provides superior grease cutting power",
                    3.75M,
                    "AUD"),
                new("Coles Bakery Rustic Rolls",
                    "https://shop.coles.com.au/wcsstore/Coles-CAS/images/7/8/8/7885766.jpg",
                    "Perfect for breakfast, lunch, dinner or a snack in between - simply add your favourite filling.",
                    3.00M,
                    "AUD"),
                new("Leggo's Bolognese with Chunky Tomato Garlic & Herbs Pasta Sauce",
                    "https://shop.coles.com.au/wcsstore/Coles-CAS/images/2/6/8/2683924.jpg",
                    "Legos Pasta Sauce a rich, delicious tomato sauce with garlic and herbs. A true favourite!",
                    2.50M,
                    "AUD"),
                new("Mount Franklin Lime Flavoured Lightly Sparkling Water Can 250mL",
                    "https://shop.coles.com.au/wcsstore/Coles-CAS/images/3/0/4/3048284.jpg",
                    "Pure Australia Spring Water infused with delicate bubbles and a hint of natural Lime flavour. ",
                    3.00M,
                    "AUD"),
            };
        }

        static IEnumerable<Cost> GetCosts()
        {
            return new List<Cost> {
                new(10.00M,0.00M,50.00M),
                new(20.00M,50.01M,decimal.MaxValue)
            };
        }

        static IEnumerable<Currency> GetCurrencies()
        {
            return new List<Currency>
            {
                new("AUD",1.00M,"$"),
                new("USD",0.72M,"$"),
                new("NZS",1.70M,"$"),
                new("CNY",4.54M,"¥"),
            };
        }
    }
}