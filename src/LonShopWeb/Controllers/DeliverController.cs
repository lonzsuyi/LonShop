using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using LonShop.BaseCore.Interfaces;
using LonShop.BaseCore.Constants;

namespace LonShop.LonShopWeb.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class DeliverController : ControllerBase
    {
        private readonly IDeliverService _deliverService;
        private readonly IAppLogger<DeliverController> _logger;

        public DeliverController(
            IDeliverService deliverService,
            IAppLogger<DeliverController> logger
        )
        {
            _deliverService = deliverService;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCost([FromQuery] decimal totalPrice)
        {
            var result = await _deliverService.GetCost(totalPrice);
            if (result != null)
            {
                return Ok(result);
            }

            ModelState.AddModelError(string.Empty, MsgStatusCode.Code400);
            return BadRequest(ModelState);
        }

    }
}