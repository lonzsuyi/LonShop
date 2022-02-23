using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using LonShop.BaseCore.Interfaces;
using LonShop.BaseCore.Entities.BasketAggregate;
using LonShop.BaseCore.Services;
using LonShop.BaseCore.Specifications;

namespace LonShop.UnitTests.BaseCore.Services.BasketServiceTests
{
    public class AddItemToBasket
    {
        private readonly string _buyerId = "Test buyerId1";
        private readonly Mock<IRepository<Basket>> _mockBasketRepo = new();

        [Fact]
        public async Task InvokesBasketRepositoryGetBySpecAsyncOnce()
        {
            var goodId = Guid.NewGuid();
            var basket = new Basket(_buyerId);
            basket.AddItem(goodId, It.IsAny<decimal>(), It.IsAny<int>());
            _mockBasketRepo.Setup(x => x.GetBySpecAsync(It.IsAny<BasketWithItemsSpecification>(), default)).ReturnsAsync(basket);

            var basketService = new BasketService(_mockBasketRepo.Object, null);

            await basketService.AddItemToBasket(basket.BuyerId, goodId, 1.50m);

            _mockBasketRepo.Verify(x => x.GetBySpecAsync(It.IsAny<BasketWithItemsSpecification>(), default), Times.Once);
        }

        [Fact]
        public async Task InvokesBasketRepositoryUpdateAsyncOnce()
        {
            var goodId = Guid.NewGuid();
            var basket = new Basket(_buyerId);
            basket.AddItem(goodId, It.IsAny<decimal>(), It.IsAny<int>());
            _mockBasketRepo.Setup(x => x.GetBySpecAsync(It.IsAny<BasketWithItemsSpecification>(), default)).ReturnsAsync(basket);

            var basketService = new BasketService(_mockBasketRepo.Object, null);

            await basketService.AddItemToBasket(basket.BuyerId, goodId, 1.50m);

            _mockBasketRepo.Verify(x => x.UpdateAsync(basket, default), Times.Once);
        }
    }
}