using System;
using System.Threading.Tasks;
using Moq;
using Xunit;
using LonShop.BaseCore.Interfaces;
using LonShop.BaseCore.Entities.BasketAggregate;
using LonShop.BaseCore.Services;

namespace LonShop.UnitTests.BaseCore.Services.BasketServiceTests
{

    public class DeleteBasket
    {
        private readonly string _buyerId = "Test buyerId1";
        private readonly Mock<IRepository<Basket>> _mockBasketRepo = new();

        [Fact]
        public async Task ShouldInvokeBasketRepositoryDeleteAsyncOnce()
        {
            var goodId1 = Guid.NewGuid();
            var goodId2 = Guid.NewGuid();
            var basket = new Basket(_buyerId);
            basket.AddItem(goodId1, It.IsAny<decimal>(), It.IsAny<int>());
            basket.AddItem(goodId2, It.IsAny<decimal>(), It.IsAny<int>());
            _mockBasketRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>(), default))
                .ReturnsAsync(basket);
            var basketService = new BasketService(_mockBasketRepo.Object, null);

            await basketService.DeleteBasketAsync(It.IsAny<int>());

            _mockBasketRepo.Verify(x => x.DeleteAsync(It.IsAny<Basket>(), default), Times.Once);
        }
    }
}