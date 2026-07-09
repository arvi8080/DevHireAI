using DevHireAI.Application.DTOs.Auth;
using DevHireAI.Application.Interfaces.Repositories;
using DevHireAI.Application.Interfaces.Services;
using DevHireAI.Domain.Entities;
using System.Security.Cryptography;

namespace DevHireAI.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtService _jwtService;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public AuthService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtService jwtService,
        IRefreshTokenRepository refreshTokenRepository)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task RegisterAsync(RegisterRequest request)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);

        if (existingUser != null)
            throw new Exception("Email already exists.");

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = _passwordHasher.HashPassword(request.Password),
            Role = request.Role,
            EmailVerified = false,
            IsActive = true
        };

        await _userRepository.AddAsync(user);
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null)
            throw new Exception("Invalid email or password.");

        var validPassword = _passwordHasher.VerifyPassword(
            request.Password,
            user.PasswordHash);

        if (!validPassword)
            throw new Exception("Invalid email or password.");

        var accessToken = _jwtService.GenerateToken(user);

        var refreshToken = Convert.ToBase64String(
            RandomNumberGenerator.GetBytes(64));

        var refreshTokenEntity = new RefreshToken
        {
            UserId = user.Id,
            Token = refreshToken,
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            IsRevoked = false
        };

        await _refreshTokenRepository.AddAsync(refreshTokenEntity);

        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ExpiresAt = DateTime.UtcNow.AddHours(1)
        };
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

        var accessToken = _jwtService.GenerateToken(user);

        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = storedToken.Token,
            ExpiresAt = DateTime.UtcNow.AddHours(1)
        };
    }

    public async Task LogoutAsync(LogoutRequest request)
    {
        var storedToken = await _refreshTokenRepository
            .GetByTokenAsync(request.RefreshToken);

        if (storedToken == null)
            throw new Exception("Refresh token not found.");

        storedToken.IsRevoked = true;

        await _refreshTokenRepository.UpdateAsync(storedToken);
    }
}