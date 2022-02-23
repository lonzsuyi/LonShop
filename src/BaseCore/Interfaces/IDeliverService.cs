using System;
using System.Threading.Tasks;

namespace LonShop.BaseCore.Interfaces
{
    public interface IDeliverService
    {
        Task<Nullable<decimal>> GetCost(decimal totalPrice);
    }
}
