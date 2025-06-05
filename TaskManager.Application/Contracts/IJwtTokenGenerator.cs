namespace TaskManager.Application.Contracts;

public interface IJwtTokenGenerator
{
    string GenerateJwtToken(string userId, string email, string fullName);
}