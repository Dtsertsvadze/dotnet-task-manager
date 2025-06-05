namespace TaskManager.Infrastructure.Repositories;

public interface IRepository<T> where T : class
{
    Task CreateAsync(T entity);
    
    Task<IEnumerable<T>> GetAllAsync();
    
    Task<T?> GetByIdAsync(string id);

    Task UpdateAsync(T entity);

    Task DeleteAsync(string id);
}