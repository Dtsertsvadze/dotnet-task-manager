using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Contracts;
using TaskManager.Application.Dtos;

namespace TaskManager.API.Controllers;

[ApiController]
public class UserController(IAuthService authService) : ControllerBase
{
    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(SignUpRequestDto request)
    {
        return Ok(await authService.SignUpAsync(request));
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn(SignInRequestDto request)
    {
        return Ok(await authService.SignInAsync(request));
    }
}