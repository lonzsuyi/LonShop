using System.Threading.Tasks;
using LonShop.BaseCore.Entities.OrderAggregate;

namespace LonShop.BaseCore.Interfaces;

public interface IOrderService
{
    Task CreateOrderAsync(int basketId, long currencyId);
}
