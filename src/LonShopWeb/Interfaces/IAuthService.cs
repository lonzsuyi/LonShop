using System.Threading.Tasks;
using LonShop.LonShopWeb.ViewModels.Auth;

namespace LonShop.LonShopWeb.Interfaces
{
    public interface IAuthService
    {
        Task<SginInResultViewModel> SignIn(SignInViewModel model);
    }
}