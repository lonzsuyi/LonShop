using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LonShop.BaseCore.Interfaces;
using LonShop.BaseCore.Entities.UserAggregate;
using LonShop.BaseCore.Constants;
using LonShop.LonShopWeb.Interfaces;
using LonShop.LonShopWeb.ViewModels.Auth;

namespace LonShop.LonShopWeb.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IAppLogger<AuthController> _logger;

        public AuthController(
            IAuthService authService,
            IAppLogger<AuthController> logger
        )
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SignInViewModel model)
        {
            var result = await _authService.SignIn(model);

            if (result != null)
            {
                return Ok(result);
            }

            ModelState.AddModelError(string.Empty, MsgStatusCode.Code1001);
            return BadRequest(ModelState);
        }
    }
}