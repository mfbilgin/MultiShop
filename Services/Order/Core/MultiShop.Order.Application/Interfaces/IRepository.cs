using System.Linq.Expressions;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Interfaces;

public interface IRepository<T> where T : IEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T?> GetByAsync(Expression<Func<T, bool>> predicate);
}