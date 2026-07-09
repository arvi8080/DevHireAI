using DevHireAI.Application.Interfaces.Repositories;
using DevHireAI.Domain.Entities;
using DevHireAI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DevHireAI.Infrastructure.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly AppDbContext _context;

    public CompanyRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Company company)
    {
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Company>> GetAllAsync()
    {
        return await _context.Companies.ToListAsync();
    }

    public async Task<Company?> GetByIdAsync(Guid id)
    {
        return await _context.Companies.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Company?> GetByOwnerIdAsync(Guid ownerId)
    {
        return await _context.Companies.FirstOrDefaultAsync(c => c.OwnerId == ownerId);
    }

    public async Task DeleteAsync(Company company)
    {
        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();
    }
}