using System.Collections.Generic;
using Ardalis.GuardClauses;
using LonShop.BaseCore.Interfaces;

namespace LonShop.BaseCore.Entities.OrderAggregate
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public long Id { get; private set; }
        public string BuyerId { get; private set; }

        public long CurrencyId { get; private set; }

        private Order()
        {
            // required by EF
        }

        public Order(string buyerId, long currencyId, List<OrderItem> items)
        {
            Guard.Against.NullOrEmpty(buyerId, nameof(buyerId));
            Guard.Against.Null(items, nameof(items));

            BuyerId = buyerId;
            CurrencyId = currencyId;
            _orderItems = items;
        }

        private readonly List<OrderItem> _orderItems = new List<OrderItem>();

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public decimal Total()
        {
            var total = 0m;
            foreach (var item in _orderItems)
            {
                total += item.UnitPrice * item.Units;
            }
            return total;
        }
    }
}