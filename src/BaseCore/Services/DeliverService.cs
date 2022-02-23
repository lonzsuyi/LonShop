using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using LonShop.BaseCore.Entities.DeliverAggregate;
using LonShop.BaseCore.Interfaces;

namespace LonShop.BaseCore.Services
{
    public class DeliverService : IDeliverService
    {
        private readonly IRepository<Cost> _costRepository;
        private readonly IAppLogger<DeliverService> _logger;

        public DeliverService(
            IRepository<Cost> costRepository,
            IAppLogger<DeliverService> logger
        )
        {
            _costRepository = costRepository;
            _logger = logger;
        }

        public async Task<Nullable<decimal>> GetCost(decimal totalPrice)
        {
            try
            {
                var costs = await _costRepository.ListAsync();
                // Calculate the total
                var cost = costs.First(p => Decimal.Compare(totalPrice, p.MinRange) >= 0 && (Decimal.Compare(totalPrice, p.MaxRange) <= 0));

                return cost != null ? cost.Price : 0.00M;
            }
            catch (Exception ex)
            {
                _logger.LogError("get cost error. \n{0}", ex.Message);
                return null;
            }
        }
    }
}