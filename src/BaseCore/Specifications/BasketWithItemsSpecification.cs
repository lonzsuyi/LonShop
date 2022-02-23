using Ardalis.Specification;
using LonShop.BaseCore.Entities.BasketAggregate;

namespace LonShop.BaseCore.Specifications
{
    public sealed class BasketWithItemsSpecification : Specification<Basket>, ISingleResultSpecification
    {
        public BasketWithItemsSpecification(long basketId)
        {
            Query
                .Where(b => b.Id == basketId)
                .Include(b => b.Items);
        }

        public BasketWithItemsSpecification(string buyerId)
        {
            Query
                .Where(b => b.BuyerId == buyerId)
                .Include(b => b.Items);
        }
    }
}