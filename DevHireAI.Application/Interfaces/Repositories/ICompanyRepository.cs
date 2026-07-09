using DevHireAI.Domain.Entities;

namespace DevHireAI.Application.Interfaces.Repositories;

public interface ICompanyRepository
{
    Task AddAsync(Company company);

    Task<List<Company>> GetAllAsync();

    Task<Company?> GetByIdAsync(Guid id);

    Task<Company?> GetByOwnerIdAsync(Guid ownerId);

    Task DeleteAsync(Company company);
}