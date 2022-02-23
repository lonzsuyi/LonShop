using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using LonShop.BaseCore.Interfaces;
using LonShop.BaseCore.Entities.GoodAggregate;

namespace LonShop.LonShopWeb.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class GoodController : ControllerBase
    {
        private readonly IGoodService _goodService;
        private readonly IAppLogger<GoodController> _logger;

        public GoodController(
            IGoodService goodService,
            IAppLogger<GoodController> logger
        )
        {
            _goodService = goodService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetGoods()
        {
            var result = await _goodService.GetGoods();
            return Ok(result);
        }
    }
}