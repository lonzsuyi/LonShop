using System.Collections.Generic;
using System.Linq;
using LonShop.BaseCore.Entities.BasketAggregate;
using LonShop.BaseCore.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class BasketGuards
    {
        public static void NullBasket(this IGuardClause guardClause, long basketId, Basket basket)
        {
            if (basket == null)
                throw new BasketNotFoundException(basketId);
        }

        public static void EmptyBasketOnCheckout(this IGuardClause guardClause, IReadOnlyCollection<BasketItem> basketItems)
        {
            if (!basketItems.Any())
                throw new EmptyBasketOnCheckoutException();
        }
    }
}