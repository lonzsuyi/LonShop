using System;
using System.ComponentModel.DataAnnotations;
using LonShop.BaseCore.Constants;

namespace LonShop.LonShopWeb.ViewModels.Order
{
    public class CreateOrderViewModel
    {
        [Required(ErrorMessage = MsgStatusCode.Code1101)]
        public int BasketId { get; set; }

        [Required(ErrorMessage = MsgStatusCode.Code1101)]
        public long CurrencyId { get; set; }
    }
}