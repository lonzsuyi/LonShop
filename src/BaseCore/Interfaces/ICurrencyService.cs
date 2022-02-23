using System.Collections.Generic;
using System.Threading.Tasks;
using LonShop.BaseCore.Entities.CurrencyAggregate;

namespace LonShop.BaseCore.Interfaces
{
    public interface ICurrencyService
    {
        Task<List<Currency>> GetCurrencies();
    }
}