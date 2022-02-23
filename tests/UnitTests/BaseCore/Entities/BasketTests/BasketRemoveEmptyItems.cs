using System;
using Xunit;
using LonShop.BaseCore.Entities.BasketAggregate;

namespace LonShop.UnitTests.BaseCore.Entities.BasketTests
{
    public class BasketRemoveEmptyItems
    {
        private readonly Guid _goodId = Guid.NewGuid();
        private readonly decimal _testUnitPrice = 1.23m;
        private readonly string _buyerId = "Test buyerId";

        [Fact]
        public void RemovesEmptyBasketItems()
        {
            var basket = new Basket(_buyerId);
            basket.AddItem(_goodId, _testUnitPrice, 0);
            basket.RemoveEmptyItems();

            Assert.Equal(0, basket.Items.Count);
        }
    }
}