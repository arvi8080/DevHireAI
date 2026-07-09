using DevHireAI.Application.DTOs.Auth;

namespace DevHireAI.Application.Interfaces.Services;

public interface IRefreshTokenService
{
    Task<AuthResponse> RefreshTokenAsync(RefreshTokenRequest request);

    Task RevokeTokenAsync(string refreshToken);
}