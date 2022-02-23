using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LonShop.BaseCore.Entities.BasketAggregate;

namespace LonShop.BaseCore.Interfaces
{
    public interface IBasketService
    {
        Task TransferBasketAsync(string anonymousId, string userName);
        Task<Basket> AddItemToBasket(string username, Guid goodId, decimal price, int quantity = 1);
        Task<Basket> SetQuantities(long basketId, Dictionary<string, int> quantities);
        Task DeleteBasketAsync(long basketId);
    }
}