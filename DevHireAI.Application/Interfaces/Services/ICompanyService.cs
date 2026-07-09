using DevHireAI.Application.DTOs.Company;

namespace DevHireAI.Application.Interfaces.Services;

public interface ICompanyService
{
    Task CreateCompanyAsync(CreateCompanyRequest request, Guid ownerId);

    Task<List<CompanyResponse>> GetAllCompaniesAsync();

    Task<CompanyResponse?> GetCompanyByIdAsync(Guid id);

    Task DeleteCompanyAsync(Guid id);
}