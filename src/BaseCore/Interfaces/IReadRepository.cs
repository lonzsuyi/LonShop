using Ardalis.Specification;

namespace LonShop.BaseCore.Interfaces
{
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}