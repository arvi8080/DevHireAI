using DevHireAI.Domain.Entities;

namespace DevHireAI.Application.Interfaces.Services;

public interface IJwtService
{
    string GenerateToken(User user);
}