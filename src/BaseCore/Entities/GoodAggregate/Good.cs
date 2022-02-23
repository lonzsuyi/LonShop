using System;
using Ardalis.GuardClauses;
using LonShop.BaseCore.Interfaces;

namespace LonShop.BaseCore.Entities.GoodAggregate
{
    public class Good : BaseEntity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string PicUrl { get; private set; }
        public string Intro { get; private set; }
        public decimal Price { get; private set; }
        public string Currency { get; private set; }

        public Good(string name,
            string picUrl,
            string intro,
            decimal price,
            string currency)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(picUrl, nameof(picUrl));
            Guard.Against.NullOrEmpty(intro, nameof(intro));
            Guard.Against.NegativeOrZero(price, nameof(price));
            Guard.Against.NullOrEmpty(currency, nameof(currency));

            Id = Guid.NewGuid();
            Name = name;
            PicUrl = picUrl;
            Intro = intro;
            Price = price;
            Currency = currency;
        }

    }
}