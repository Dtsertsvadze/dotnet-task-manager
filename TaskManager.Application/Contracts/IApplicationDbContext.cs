using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Contracts;

public interface IApplicationDbContext
{
    DbSet<ApplicationUser> Users { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}