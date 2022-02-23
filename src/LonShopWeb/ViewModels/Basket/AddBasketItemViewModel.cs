using System;
using System.ComponentModel.DataAnnotations;
using LonShop.BaseCore.Constants;

namespace LonShop.LonShopWeb.ViewModels.Basket
{
    public class AddBasketItemViewModel
    {
        [Required(ErrorMessage = MsgStatusCode.Code1101)]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Required(ErrorMessage = MsgStatusCode.Code1101)]
        public Guid GoodId { get; set; }
    }
}