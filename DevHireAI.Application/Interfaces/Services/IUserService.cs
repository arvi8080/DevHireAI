using DevHireAI.Application.DTOs.User;

namespace DevHireAI.Application.Interfaces.Services;

public interface IUserService
{
    Task<List<UserDto>> GetAllUsersAsync();
    Task<UserDto?> GetUserByIdAsync(Guid id);
}