using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using LonShop.BaseCore.Constants;
using LonShop.BaseCore.Interfaces;
using LonShop.LonShopWeb.Interfaces;
using LonShop.LonShopWeb.ViewModels.Basket;

namespace LonShop.LonShopWeb.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IBasketViewModelService _basketViewModelService;
        private readonly IAppLogger<BasketController> _logger;

        public BasketController(
            IBasketService basketService,
            IBasketViewModelService basketViewModelService,
            IAppLogger<BasketController> logger
        )
        {
            _basketService = basketService;
            _basketViewModelService = basketViewModelService;
            _logger = logger;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetOrCreateBasket()
        {
            var currentUserName = User.Identity.Name;
            var result = await _basketViewModelService.GetOrCreateBasketForUser(currentUserName);

            if (result != null)
            {
                return Ok(result);
            }

            ModelState.AddModelError(string.Empty, MsgStatusCode.Code1001);
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] AddBasketItemViewModel model)
        {
            var currentUserName = User.Identity.Name;
            var result = await _basketService.AddItemToBasket(currentUserName, model.GoodId, model.Price, model.Quantity);

            if (result != null)
            {
                return Ok(await _basketViewModelService.Map(result));
            }

            ModelState.AddModelError(string.Empty, MsgStatusCode.Code400);
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateBasket([FromBody] UpdateBasketViewModel model)
        {
            var result = await _basketService.SetQuantities(model.Id, model.quantities);
            if (result != null)
            {
                return Ok(await _basketViewModelService.Map(result));
            }

            ModelState.AddModelError(string.Empty, MsgStatusCode.Code400);
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteBasket([FromBody] DeleteBasketViewModel model)
        {
            await _basketService.DeleteBasketAsync(model.Id);

            return Ok(true);
        }
    }
}