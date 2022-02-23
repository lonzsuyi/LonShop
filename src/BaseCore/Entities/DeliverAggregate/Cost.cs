using Ardalis.GuardClauses;
using LonShop.BaseCore.Interfaces;

namespace LonShop.BaseCore.Entities.DeliverAggregate
{
    public class Cost : BaseEntity, IAggregateRoot
    {
        public int Id { get; private set; }

        public decimal Price { get; private set; }

        public decimal MinRange { get; private set; }

        public decimal MaxRange { get; private set; }

        public Cost(
            decimal price,
            decimal minRange,
            decimal maxRange
        )
        {
            Price = price;
            MinRange = minRange;
            MaxRange = maxRange;
        }
    }
}