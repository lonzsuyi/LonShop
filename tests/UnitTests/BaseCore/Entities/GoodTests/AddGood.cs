using Xunit;
using LonShop.BaseCore.Entities.GoodAggregate;

namespace LonShop.UnitTests.BaseCore.Entities.GoodTests
{
    public class AddGood
    {
        private readonly string _name = "Schweppes Lemonade Multipack Mini Cans 200mL";
        private readonly string _picUrl = "https://shop.coles.com.au/wcsstore/Coles-CAS/images/2/0/0/2007510.jpg";
        private readonly decimal _price = 6.18M;
        private readonly string _intro = "With a harmonious blend of lemon and lime oils, Schweppes Lemonade 200mL delivers";
        private readonly string _currency = "AUD";

        [Fact]
        public void AddGoodIfNotPresent()
        {
            var good = new Good(_name, _picUrl, _intro, _price, _currency);
            Assert.Equal(_name, good.Name);
            Assert.Equal(_picUrl, good.PicUrl);
            Assert.Equal(_price, good.Price);
            Assert.Equal(_intro, good.Intro);
            Assert.Equal(_currency, good.Currency);
        }
    }
}