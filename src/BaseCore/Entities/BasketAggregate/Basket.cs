using System;
using System.Collections.Generic;
using System.Linq;
using LonShop.BaseCore.Interfaces;

namespace LonShop.BaseCore.Entities.BasketAggregate
{
    public class Basket : BaseEntity, IAggregateRoot
    {
        public long Id { get; private set; }
        public string BuyerId { get; private set; }
        private readonly List<BasketItem> _items = new List<BasketItem>();
        public IReadOnlyCollection<BasketItem> Items => _items.AsReadOnly();

        public Basket(string buyerId)
        {
            BuyerId = buyerId;
        }

        public int TotalItems => _items.Sum(i => i.Quantity);

        public void AddItem(Guid goodId, decimal unitPrice, int quantity = 1)
        {
            if (!Items.Any(i => i.GoodId == goodId))
            {
                _items.Add(new BasketItem(unitPrice, quantity, true, goodId));
                return;
            }
            var existingItem = Items.FirstOrDefault(i => i.GoodId == goodId);
            existingItem.AddQuantity(quantity);
        }

        public void RemoveEmptyItems()
        {
            _items.RemoveAll(i => i.Quantity == 0);
        }

        public void SetNewBuyerId(string buyerId)
        {
            BuyerId = buyerId;
        }
    }
}