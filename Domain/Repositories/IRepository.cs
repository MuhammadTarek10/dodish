using System.Linq.Expressions;

namespace Domain.Repositories;

public interface IRepository<T> where T : class, IEntityWithGuidId
{
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = false);
    Task<T?> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
    Task<Guid> AddAsync(T entity);
    Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);
}
