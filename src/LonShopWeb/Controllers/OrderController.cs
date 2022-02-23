using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using LonShop.BaseCore.Interfaces;
using LonShop.LonShopWeb.ViewModels.Order;

namespace LonShop.LonShopWeb.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IAppLogger<OrderController> _logger;

        public OrderController(
            IOrderService orderService,
            IAppLogger<OrderController> logger
        )
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderViewModel model)
        {
            await _orderService.CreateOrderAsync(model.BasketId, model.CurrencyId);

            return Ok(true);
        }
    }
}