using DevHireAI.Domain.Entities;

namespace DevHireAI.Application.Interfaces.Repositories;

public interface IJobRepository
{
    Task<List<Job>> GetAllAsync();
    Task<Job?> GetByIdAsync(Guid id);
    Task AddAsync(Job job);
    Task DeleteAsync(Job job);
}