using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Contracts;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext dbContext)
    : Repository<ApplicationUser>(dbContext), IUserRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<ApplicationUser> GetUserByEmail(string email)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (user is null)
            throw new KeyNotFoundException(
                $"User with email '{email}' was not found.");

        return user;
    }
}