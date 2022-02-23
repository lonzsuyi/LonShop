using System;
using System.Collections.Generic;
using System.Linq;


namespace LonShop.LonShopWeb.ViewModels.Basket
{
    public class BasketViewModel
    {
        public long Id { get; set; }
        public List<BasketItemViewModel> Items { get; set; } = new List<BasketItemViewModel>();
        public string BuyerId { get; set; }

        public decimal Total()
        {
            return Math.Round(Items.Sum(x => x.UnitPrice * x.Quantity), 2);
        }
    }
}