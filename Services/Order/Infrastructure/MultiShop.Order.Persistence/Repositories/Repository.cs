using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using MultiShop.Order.Persistence.Contexts;

namespace MultiShop.Order.Persistence.Repositories;

public class Repository<T>(OrderContext context) : IRepository<T> where T : class, IEntity
{
    public async Task<T?> GetByIdAsync(int id)
    {
        return await context.Set<T>().FindAsync(id); 
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task CreateAsync(T entity)
    {
        context.Set<T>().Add(entity);
        await context.SaveChangesAsync();   
    }

    public async Task UpdateAsync(T entity)
    {
        context.Set<T>().Update(entity); 
        await context.SaveChangesAsync();
        
    }

    public async Task DeleteAsync(T entity)
    {
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<T?> GetByAsync(Expression<Func<T, bool>> predicate)
    {
        return await context.Set<T>().SingleOrDefaultAsync(predicate); 
    }
}