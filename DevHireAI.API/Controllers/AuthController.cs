using DevHireAI.Application.DTOs.Auth;
using DevHireAI.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevHireAI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _authService.RegisterAsync(request);

        return Ok(new
        {
            Message = "User registered successfully."
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var response = await _authService.LoginAsync(request);

        return Ok(response);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken(RefreshTokenRequest request)
    {
        var response = await _authService.RefreshTokenAsync(request);
        return Ok(response);
    }



    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
    {
        await _authService.LogoutAsync(request);
        return Ok(new
        {
            Message = "Logged out successfully."
        });
    }




}