using System.Collections.Generic;
using System.Threading.Tasks;
using LonShop.BaseCore.Entities.GoodAggregate;

namespace LonShop.BaseCore.Interfaces
{
    public interface IGoodService
    {
        Task<List<Good>> GetGoods();
    }
}