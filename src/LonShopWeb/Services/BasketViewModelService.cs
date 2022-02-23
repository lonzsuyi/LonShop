using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LonShop.BaseCore.Interfaces;
using LonShop.BaseCore.Entities.BasketAggregate;
using LonShop.BaseCore.Entities.GoodAggregate;
using LonShop.BaseCore.Specifications;
using LonShop.LonShopWeb.Interfaces;
using LonShop.LonShopWeb.ViewModels.Basket;

namespace LonShop.LonShopWeb.Services
{
    public class BasketViewModelService : IBasketViewModelService
    {
        private readonly IRepository<Basket> _basketRepository;
        private readonly IRepository<Good> _goodRepository;
        private readonly IAppLogger<BasketViewModelService> _logger;

        public BasketViewModelService(
            IRepository<Basket> basketRepository,
            IRepository<Good> goodRepository,
            IAppLogger<BasketViewModelService> logger
        )
        {
            _goodRepository = goodRepository;
            _basketRepository = basketRepository;
            _logger = logger;
        }

        public async Task<BasketViewModel> GetOrCreateBasketForUser(string userName)
        {
            try
            {
                var basketSpec = new BasketWithItemsSpecification(userName);
                var basket = (await _basketRepository.GetBySpecAsync(basketSpec));

                if (basket == null)
                {
                    return await CreateBasketForUser(userName);
                }
                var viewModel = await Map(basket);
                return viewModel;
            }
            catch (Exception ex)
            {
                _logger.LogError("Get or create basket for user error. /n{0}", ex.Message);
                return null;
            }

        }

        private async Task<BasketViewModel> CreateBasketForUser(string userId)
        {
            var basket = new Basket(userId);
            await _basketRepository.AddAsync(basket);

            return new BasketViewModel()
            {
                BuyerId = basket.BuyerId,
                Id = basket.Id,
            };
        }

        private async Task<List<BasketItemViewModel>> GetBasketItems(IReadOnlyCollection<BasketItem> basketItems)
        {
            var goodSpecification = new GoodsSpecification(basketItems.Select(b => b.GoodId).ToArray());
            var goods = await _goodRepository.ListAsync(goodSpecification);

            var items = basketItems.Select(basketItem =>
            {
                var good = goods.First(c => c.Id == basketItem.GoodId);

                var basketItemViewModel = new BasketItemViewModel
                {
                    Id = basketItem.Id,
                    GoodId = basketItem.GoodId,
                    UnitPrice = basketItem.UnitPrice,
                    Quantity = basketItem.Quantity,
                    Good = good
                };
                return basketItemViewModel;
            }).ToList();

            return items;
        }

        public async Task<BasketViewModel> Map(Basket basket)
        {
            return new BasketViewModel()
            {
                BuyerId = basket.BuyerId,
                Id = basket.Id,
                Items = await GetBasketItems(basket.Items)
            };
        }
    }
}

