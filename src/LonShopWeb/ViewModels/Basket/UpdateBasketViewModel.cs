using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LonShop.BaseCore.Constants;

namespace LonShop.LonShopWeb.ViewModels.Basket
{
    public class UpdateBasketViewModel
    {
        [Required(ErrorMessage = MsgStatusCode.Code1101)]
        public long Id { get; set; }

        [Required(ErrorMessage = MsgStatusCode.Code1101)]
        public Dictionary<string, int> quantities { get; set; }

    }
}