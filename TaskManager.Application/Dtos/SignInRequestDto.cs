using System.ComponentModel.DataAnnotations;

namespace TaskManager.Application.Dtos;

public class SignInRequestDto
{
    [Required]
    public string Email { get; init; }
    
    [Required]
    public string Password { get; init; }
}