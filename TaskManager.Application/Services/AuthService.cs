using System.ComponentModel.DataAnnotations;
using TaskManager.Application.Contracts;
using TaskManager.Application.Dtos;

namespace TaskManager.Application.Services;

public class AuthService(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IJwtTokenGenerator tokenGenerator)
    : IAuthService
{
    public async Task<SignInResponseDto> SignInAsync(SignInRequestDto requestDto)
    {
        var user = await unitOfWork.Users.GetUserByEmail(requestDto.Email)
                   ?? throw new UnauthorizedAccessException("Invalid credentials");

        if (!passwordHasher.VerifyPassword(requestDto.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid credentials");

        var token = tokenGenerator.GenerateJwtToken(user.Id, user.Email, user.FullName);

        return new SignInResponseDto(token);
    }

    public async Task<SignUpResponseDto> SignUpAsync(SignUpRequestDto request)
    {
        if (!ValidateConfirmPassword(request.Password, request.ConfirmPassword))
        {
            throw new ValidationException("Passwords do not match.");
        }

        var hashedPassword = passwordHasher.HashPassword(request.Password);
        var entity = request.MapToApplicationUser(hashedPassword);
        await unitOfWork.Users.CreateAsync(entity);
        await unitOfWork.SaveChangesAsync();

        return new SignUpResponseDto(entity.Email);
    }

    private static bool ValidateConfirmPassword(
        string password, string confirmPassword)
    {
        return password == confirmPassword;
    }
}