using Microsoft.EntityFrameworkCore;

namespace TaskManager.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    protected Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task CreateAsync(T entity)
    {
        await _dbContext.AddAsync(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(string id)
    {
        return await _dbSet.FindAsync(id);
    }

    public Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);

        return Task.CompletedTask;
    }

    public async Task DeleteAsync(string id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is not null)
        {
            _dbSet.Remove(entity);
        }
    }
}