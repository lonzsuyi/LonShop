using System.Threading.Tasks;
using LonShop.BaseCore.Entities.BasketAggregate;
using LonShop.LonShopWeb.ViewModels.Basket;

namespace LonShop.LonShopWeb.Interfaces;

public interface IBasketViewModelService
{
    Task<BasketViewModel> GetOrCreateBasketForUser(string userName);
    Task<BasketViewModel> Map(Basket basket);
}