using DevHireAI.Application.DTOs.Auth;

namespace DevHireAI.Application.Interfaces.Services;

public interface IAuthService
{
    Task RegisterAsync(RegisterRequest request);

    Task<AuthResponse> LoginAsync(LoginRequest request);

    Task<AuthResponse> RefreshTokenAsync(RefreshTokenRequest request);

    Task LogoutAsync(LogoutRequest request);
}