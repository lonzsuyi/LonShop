using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using LonShop.BaseCore.Entities.CurrencyAggregate;
using LonShop.BaseCore.Interfaces;

namespace LonShop.BaseCore.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IRepository<Currency> _currencyRepository;
        private readonly IAppLogger<CurrencyService> _logger;

        public CurrencyService(
            IRepository<Currency> currencyRepository,
            IAppLogger<CurrencyService> logger
        )
        {
            _currencyRepository = currencyRepository;
            _logger = logger;
        }

        public async Task<List<Currency>> GetCurrencies()
        {
            try
            {
                return await _currencyRepository.ListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("get currencies error. \n{0}", ex.Message);
                return null;
            }
        }
    }
}