namespace TaskManager.Domain.Entities;

public class ApplicationUser
{
    public string Email { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string FullName => $"{FirstName} {LastName}";
}