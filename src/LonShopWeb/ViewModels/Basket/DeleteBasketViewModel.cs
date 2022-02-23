using System.ComponentModel.DataAnnotations;
using LonShop.BaseCore.Constants;

namespace LonShop.LonShopWeb.ViewModels.Basket
{
    public class DeleteBasketViewModel
    {
        [Required(ErrorMessage = MsgStatusCode.Code1101)]
        public long Id;
    }
}