using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using LonShop.BaseCore.Entities.BasketAggregate;
using LonShop.BaseCore.Interfaces;
using LonShop.BaseCore.Specifications;
using LonShop.BaseCore.Exceptions;

namespace LonShop.BaseCore.Services
{
    public class BasketService : IBasketService
    {
        private readonly IRepository<Basket> _basketRepository;
        private readonly IAppLogger<BasketService> _logger;

        public BasketService(IRepository<Basket> basketRepository,
        IAppLogger<BasketService> logger)
        {
            _basketRepository = basketRepository;
            _logger = logger;
        }

        public async Task<Basket> AddItemToBasket(string username, Guid goodId, decimal price, int quantity = 1)
        {
            try
            {
                var basketSpec = new BasketWithItemsSpecification(username);
                var basket = await _basketRepository.GetBySpecAsync(basketSpec);

                if (basket == null)
                {
                    basket = new Basket(username);
                    await _basketRepository.AddAsync(basket);
                }

                basket.AddItem(goodId, price, quantity);

                await _basketRepository.UpdateAsync(basket);
                return basket;
            }
            catch (Exception ex)
            {
                _logger.LogError("Add item to basket error /n{0}", ex.Message);
                return null;
            }
        }

 
        public async Task DeleteBasketAsync(long basketId)
        {
            try
            {
                var basket = await _basketRepository.GetByIdAsync(basketId);
                await _basketRepository.DeleteAsync(basket);
            }
            catch (Exception ex)
            {
                _logger.LogError("Delete basket error /n{0}", ex.Message);
            }
        }

        public async Task<Basket> SetQuantities(long basketId, Dictionary<string, int> quantities)
        {
            try
            {
                Guard.Against.Null(quantities, nameof(quantities));
                var basketSpec = new BasketWithItemsSpecification(basketId);
                var basket = await _basketRepository.GetBySpecAsync(basketSpec);
                Guard.Against.NullBasket(basketId, basket);

                foreach (var item in basket.Items)
                {
                    if (quantities.TryGetValue(item.Id.ToString(), out var quantity))
                    {
                        if (_logger != null) _logger.LogInformation($"Updating quantity of item ID:{item.Id} to {quantity}.");
                        item.SetQuantity(quantity);
                    }
                }
                basket.RemoveEmptyItems();
                await _basketRepository.UpdateAsync(basket);
                return basket;
            }
            catch (Exception ex)
            {
                _logger.LogError("Set Quantities error /n{0}", ex.Message);
                return null;
            }
        }

        public async Task TransferBasketAsync(string anonymousId, string userName)
        {
            try
            {
                Guard.Against.NullOrEmpty(anonymousId, nameof(anonymousId));
                Guard.Against.NullOrEmpty(userName, nameof(userName));
                var anonymousBasketSpec = new BasketWithItemsSpecification(anonymousId);
                var anonymousBasket = await _basketRepository.GetBySpecAsync(anonymousBasketSpec);
                if (anonymousBasket == null) return;
                var userBasketSpec = new BasketWithItemsSpecification(userName);
                var userBasket = await _basketRepository.GetBySpecAsync(userBasketSpec);
                if (userBasket == null)
                {
                    userBasket = new Basket(userName);
                    await _basketRepository.AddAsync(userBasket);
                }
                foreach (var item in anonymousBasket.Items)
                {
                    userBasket.AddItem(item.GoodId, item.UnitPrice, item.Quantity);
                }
                await _basketRepository.UpdateAsync(userBasket);
                await _basketRepository.DeleteAsync(anonymousBasket);
            }
            catch (Exception ex)
            {
                _logger.LogError("Transfer basket error /n{0}", ex.Message);
            }
        }
    }
}