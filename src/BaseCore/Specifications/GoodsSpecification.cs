using System;
using System.Linq;
using Ardalis.Specification;
using LonShop.BaseCore.Entities.GoodAggregate;

namespace LonShop.BaseCore.Specifications
{
    public class GoodsSpecification : Specification<Good>
    {
        public GoodsSpecification(params Guid[] ids)
        {
            Query.Where(c => ids.Contains(c.Id));
        }
    }
}