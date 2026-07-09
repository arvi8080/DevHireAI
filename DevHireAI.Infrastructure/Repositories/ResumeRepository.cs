using DevHireAI.Application.Interfaces.Repositories;
using DevHireAI.Domain.Entities;
using DevHireAI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DevHireAI.Infrastructure.Repositories;

public class ResumeRepository : IResumeRepository
{
    private readonly AppDbContext _context;

    public ResumeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Resume resume)
    {
        await _context.Resumes.AddAsync(resume);
        await _context.SaveChangesAsync();
    }

    public async Task<Resume?> GetByUserIdAsync(Guid userId)
    {
        return await _context.Resumes
            .FirstOrDefaultAsync(r => r.UserId == userId);
    }

    public async Task DeleteAsync(Resume resume)
    {
        _context.Resumes.Remove(resume);
        await _context.SaveChangesAsync();
    }
}