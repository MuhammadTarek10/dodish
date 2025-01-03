using System.Linq.Expressions;
using Domain.Repositories;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class Repository<T>(AppDbContext context) : IRepository<T> where T : class, IEntityWithGuidId
{
    private readonly DbSet<T> dbSet = context.Set<T>();

    public async Task<Guid> AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
    {
        return await dbSet.AnyAsync(filter);
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = false)
    {
        IQueryable<T> query = tracked ? dbSet : dbSet.AsNoTracking();

        if (filter != null) query = query.Where(filter);

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        return await query.ToListAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
    {
        IQueryable<T> query = tracked ? dbSet : dbSet.AsNoTracking();

        if (filter != null) query = query.Where(filter);

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        dbSet.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        dbSet.Update(entity);
        await context.SaveChangesAsync();
    }
}
