using TaskManager.Infrastructure.Repositories;

namespace TaskManager.Infrastructure.Uow;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}