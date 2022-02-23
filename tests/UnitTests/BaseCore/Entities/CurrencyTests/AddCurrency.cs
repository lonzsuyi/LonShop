using Xunit;
using LonShop.BaseCore.Entities.CurrencyAggregate;

namespace LonShop.UnitTests.BaseCore.Entities.CurrencyTests
{
    public class AddCurrency
    {
        private readonly string _code = "AUD";
        private readonly decimal _rate = 1.00M;
        private readonly string _symbol = "$";

        [Fact]
        public void AddCurrencyIfNotPresent()
        {
            var currency = new Currency(_code, _rate, _symbol);

            Assert.Equal(_code, currency.Code);
            Assert.Equal(_rate, currency.Rate);
            Assert.Equal(_symbol, currency.Symbol);
        }
    }
}
