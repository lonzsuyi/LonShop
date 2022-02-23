using Ardalis.Specification;

namespace LonShop.BaseCore.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}