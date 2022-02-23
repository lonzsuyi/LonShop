using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using LonShop.BaseCore.Entities.GoodAggregate;
using LonShop.BaseCore.Interfaces;

namespace LonShop.BaseCore.Services
{
    public class GoodService : IGoodService
    {
        private readonly IRepository<Good> _goodRepository;
        private readonly IAppLogger<GoodService> _logger;

        public GoodService(
            IRepository<Good> goodRepository,
            IAppLogger<GoodService> logger
        )
        {
            _goodRepository = goodRepository;
            _logger = logger;
        }

        public async Task<List<Good>> GetGoods()
        {
            try
            {
                return await _goodRepository.ListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Get goods error. \n{0}", ex.Message);
                return null;
            }
        }
    }
}