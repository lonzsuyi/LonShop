using System;

namespace LonShop.BaseCore.Entities.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        public long Id { get; private set; }
        public Guid GoodId { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Units { get; private set; }

        private OrderItem()
        {
            // required by EF
        }

        public OrderItem(Guid goodId, decimal unitPrice, int units)
        {
            GoodId = goodId;
            UnitPrice = unitPrice;
            Units = units;
        }
    }
}