using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Repositories;

public class UserRepository : Repository<ApplicationUser>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}