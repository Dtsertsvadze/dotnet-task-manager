using TaskManager.Application.Dtos;

namespace TaskManager.Application.Contracts;

public interface IAuthService
{
    Task<SignInResponseDto> SignInAsync(SignInRequestDto request);

    Task<SignUpResponseDto> SignUpAsync(SignUpRequestDto request);
}