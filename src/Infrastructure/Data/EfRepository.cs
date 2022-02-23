using Ardalis.Specification.EntityFrameworkCore;
using LonShop.BaseCore.Interfaces;

namespace LonShop.Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public EfRepository(StoreContext dbContext) : base(dbContext)
        {
        }
    }
}

