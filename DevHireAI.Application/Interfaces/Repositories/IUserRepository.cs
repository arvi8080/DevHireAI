using DevHireAI.Domain.Entities;

namespace DevHireAI.Application.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}