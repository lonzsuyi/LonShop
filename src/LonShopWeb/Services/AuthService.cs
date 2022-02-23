using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using LonShop.BaseCore.Interfaces;
using LonShop.BaseCore.Entities.UserAggregate;
using LonShop.LonShopWeb.Interfaces;
using LonShop.LonShopWeb.ViewModels.Auth;

namespace LonShop.LonShopWeb.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenClaimsService _tokenClaimsService;

        private readonly IAppLogger<AuthService> _logger;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ITokenClaimsService tokenClaimsService,
            IAppLogger<AuthService> logger
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenClaimsService = tokenClaimsService;
            _logger = logger;
        }

        public async Task<SginInResultViewModel> SignIn(SignInViewModel model)
        {
            try
            {
                var signInResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (signInResult.Succeeded)
                {
                    var userInfo = await _userManager.FindByNameAsync(model.UserName);
                    string token = await _tokenClaimsService.GetTokenAsync(userInfo.UserName);

                    return new SginInResultViewModel
                    {
                        username = userInfo.UserName,
                        token = token
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Sign error /n{0}", ex.Message);
                return null;
            }

        }

    }
}