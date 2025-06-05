using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Dtos;

public class SignUpRequestDto
{
    [Required, EmailAddress]
    public string Email { get; init; }
    
    [Required, StringLength(20, MinimumLength = 4)]
    public string FirstName { get; init; }

    [Required, StringLength(20, MinimumLength = 4)]
    public string LastName { get; init; }
    
    [Required]
    public string Password { get; init; }
    
    [Required]
    public string ConfirmPassword { get; init; }

    public ApplicationUser MapToApplicationUser(string passwordHash)
    {
        return new ApplicationUser
        {
            Email = Email, FirstName = FirstName, LastName = LastName, PasswordHash = passwordHash
        };
    }
}