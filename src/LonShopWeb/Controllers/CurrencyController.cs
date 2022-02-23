using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using LonShop.BaseCore.Constants;
using LonShop.BaseCore.Entities.CurrencyAggregate;
using LonShop.BaseCore.Interfaces;
using LonShop.LonShopWeb.Interfaces;

namespace LonShop.LonShopWeb.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly IAppLogger<CurrencyController> _logger;

        public CurrencyController(
            ICurrencyService currencyService,
            IAppLogger<CurrencyController> logger
        )
        {
            _currencyService = currencyService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrencies()
        {
            var result = await _currencyService.GetCurrencies();
            return Ok(result);
        }

    }
}