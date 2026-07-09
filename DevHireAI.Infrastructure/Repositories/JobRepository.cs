using DevHireAI.Application.Interfaces.Repositories;
using DevHireAI.Domain.Entities;
using DevHireAI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DevHireAI.Infrastructure.Repositories;

public class JobRepository : IJobRepository
{
    private readonly AppDbContext _context;

    public JobRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Job>> GetAllAsync()
    {
        return await _context.Jobs.ToListAsync();
    }

    public async Task<Job?> GetByIdAsync(Guid id)
    {
        return await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Job job)
    {
        await _context.Jobs.AddAsync(job);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Job job)
    {
        _context.Jobs.Remove(job);
        await _context.SaveChangesAsync();
    }
}