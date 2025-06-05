using TaskManager.Domain.Entities;

namespace TaskManager.Application.Contracts;

public interface IUserRepository : IRepository<ApplicationUser>
{
    Task<ApplicationUser> GetUserByEmail(string email);
}