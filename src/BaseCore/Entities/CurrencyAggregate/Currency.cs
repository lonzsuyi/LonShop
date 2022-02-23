using Ardalis.GuardClauses;
using LonShop.BaseCore.Interfaces;

namespace LonShop.BaseCore.Entities.CurrencyAggregate
{
    public class Currency : BaseEntity, IAggregateRoot
    {
        public long Id { get; private set; }
        public string Code { get; private set; }
        public decimal Rate { get; private set; }
        public string Symbol { get; private set; }

        public Currency(
            string code,
            decimal rate,
            string symbol)
        {
            Guard.Against.NullOrEmpty(code, nameof(code));
            Guard.Against.NegativeOrZero(rate, nameof(rate));
            Guard.Against.NullOrEmpty(symbol, nameof(symbol));

            Code = code;
            Rate = rate;
            Symbol = symbol;
        }
    }
}