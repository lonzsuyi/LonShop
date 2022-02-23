using System;
using Ardalis.GuardClauses;

namespace LonShop.BaseCore.Entities.BasketAggregate
{
    public class BasketItem : BaseEntity
    {
        public long Id { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public bool Status { get; private set; }
        public Guid GoodId { get; private set; }
        public long BasketId { get; private set; }

        public BasketItem(
            decimal unitPrice,
            int quantity,
            bool status,
            Guid goodId)
        {
            SetQuantity(quantity);
            Status = status;
            GoodId = goodId;
        }

        public void AddQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

            Quantity += quantity;
        }

        public void SetQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

            Quantity = quantity;
        }

    }
}

