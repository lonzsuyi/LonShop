using System.ComponentModel.DataAnnotations;
using LonShop.BaseCore.Constants;

namespace LonShop.LonShopWeb.ViewModels.Auth
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = MsgStatusCode.Code1101)]
        [EmailAddress(ErrorMessage = MsgStatusCode.Code1201)]
        public string UserName { get; set; }

        [Required(ErrorMessage = MsgStatusCode.Code1101)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}