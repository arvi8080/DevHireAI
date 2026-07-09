using DevHireAI.Application.DTOs.Company;
using DevHireAI.Application.Interfaces.Repositories;
using DevHireAI.Application.Interfaces.Services;
using DevHireAI.Domain.Entities;

namespace DevHireAI.Infrastructure.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task CreateCompanyAsync(CreateCompanyRequest request, Guid ownerId)
    {
        var existingCompany = await _companyRepository.GetByOwnerIdAsync(ownerId);

        if (existingCompany != null)
            throw new Exception("You already have a company profile.");

        var company = new Company
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Website = request.Website,
            Location = request.Location,
            OwnerId = ownerId,
            CreatedAt = DateTime.UtcNow
        };

        await _companyRepository.AddAsync(company);
    }

    public async Task<List<CompanyResponse>> GetAllCompaniesAsync()
    {
        var companies = await _companyRepository.GetAllAsync();

        return companies.Select(c => new CompanyResponse
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            Website = c.Website,
            Location = c.Location,
            OwnerId = c.OwnerId,
            CreatedAt = c.CreatedAt
        }).ToList();
    }

    public async Task<CompanyResponse?> GetCompanyByIdAsync(Guid id)
    {
        var company = await _companyRepository.GetByIdAsync(id);

        if (company == null)
            return null;

        return new CompanyResponse
        {
            Id = company.Id,
            Name = company.Name,
            Description = company.Description,
            Website = company.Website,
            Location = company.Location,
            OwnerId = company.OwnerId,
            CreatedAt = company.CreatedAt
        };
    }

    public async Task DeleteCompanyAsync(Guid id)
    {
        var company = await _companyRepository.GetByIdAsync(id);

        if (company == null)
            throw new Exception("Company not found.");

        await _companyRepository.DeleteAsync(company);
    }
}