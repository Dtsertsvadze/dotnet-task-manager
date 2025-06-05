namespace TaskManager.Application.Dtos;

public class SignUpResponseDto(string email)
{
    public string? Email { get; init; } = email;

    public string Message { get; init; } = "Profile created successfully.";
}