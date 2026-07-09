using DevHireAI.Application.DTOs.Auth;
using DevHireAI.Application.Interfaces.Repositories;
using DevHireAI.Application.Interfaces.Services;
using DevHireAI.Domain.Entities;

namespace DevHireAI.Infrastructure.Services;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public RefreshTokenService(
        IRefreshTokenRepository refreshTokenRepository,
        IUserRepository userRepository,
        IJwtService jwtService)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<AuthResponse> RefreshTokenAsync(RefreshTokenRequest request)
    {
        var storedToken = await _refreshTokenRepository
            .GetByTokenAsync(request.RefreshToken);

        if (storedToken == null)
            throw new Exception("Invalid refresh token.");

        if (storedToken.IsRevoked)
            throw new Exception("Refresh token has been revoked.");

        if (storedToken.ExpiresAt <= DateTime.UtcNow)
            throw new Exception("Refresh token has expired.");

        var user = await _userRepository.GetByIdAsync(storedToken.UserId);

        if (user == null)
            throw new Exception("User not found.");

        // Generate a new JWT access token
        var accessToken = _jwtService.GenerateToken(user);

        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = storedToken.Token,
            ExpiresAt = DateTime.UtcNow.AddMinutes(30)
        };
    }

    public async Task RevokeTokenAsync(string refreshToken)
    {
        var storedToken = await _refreshTokenRepository
            .GetByTokenAsync(refreshToken);

        if (storedToken == null)
            throw new Exception("Refresh token not found.");

        storedToken.IsRevoked = true;

        await _refreshTokenRepository.UpdateAsync(storedToken);
    }
}