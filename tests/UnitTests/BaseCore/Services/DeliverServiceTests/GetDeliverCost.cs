using System;
using System.Threading.Tasks;
using Moq;
using Xunit;
using LonShop.BaseCore.Interfaces;
using LonShop.BaseCore.Services;
using LonShop.BaseCore.Entities.DeliverAggregate;

namespace LonShop.UnitTests.BaseCore.Services.DeliverServiceTests
{
    public class GetDeliverCost
    {
        private readonly decimal lessThanTotal = 40.00M;
        private readonly decimal greaterThanTotal = 60.00M;
        private readonly decimal _lessCost = 10.00M;
        private readonly decimal _greaterCost = 20.00M;
        private readonly Mock<IRepository<Cost>> _mockCostRepo = new();

        [Fact]
        public async Task CalculateIsCorrect()
        {
            var deliverService = new DeliverService(_mockCostRepo.Object, null);
            var lessCost = await deliverService.GetCost(lessThanTotal);
            Assert.Equal(_lessCost, lessCost);
            var greaterCost = await deliverService.GetCost(greaterThanTotal);
            Assert.Equal(_greaterCost, greaterCost);
        }
    }
}