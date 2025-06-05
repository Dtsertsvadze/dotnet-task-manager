namespace TaskManager.Application.Dtos;

public class SignInResponseDto(string token)
{
    public string Token { get; init; } = token;

    public string Message { get; init; } = "User Signed in successfully.";
}