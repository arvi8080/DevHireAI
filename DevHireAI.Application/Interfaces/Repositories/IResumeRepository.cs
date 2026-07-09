using DevHireAI.Domain.Entities;

namespace DevHireAI.Application.Interfaces.Repositories;

public interface IResumeRepository
{
    Task AddAsync(Resume resume);

    Task<Resume?> GetByUserIdAsync(Guid userId);

    Task DeleteAsync(Resume resume);
}