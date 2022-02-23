using System;
using System.ComponentModel.DataAnnotations;
using LonShop.BaseCore.Constants;
using LonShop.BaseCore.Entities.GoodAggregate;

namespace LonShop.LonShopWeb.ViewModels.Basket
{
    public class BasketItemViewModel
    {
        public long Id { get; set; }
        public Guid GoodId { get; set; }

        public Good Good { get; set; }

        public decimal UnitPrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = MsgStatusCode.Code1401)]
        public int Quantity { get; set; }
    }
}