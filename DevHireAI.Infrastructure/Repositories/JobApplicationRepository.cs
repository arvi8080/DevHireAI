using DevHireAI.Application.Interfaces.Repositories;
using DevHireAI.Domain.Entities;
using DevHireAI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DevHireAI.Infrastructure.Repositories;

public class JobApplicationRepository : IJobApplicationRepository
{
    private readonly AppDbContext _context;

    public JobApplicationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(JobApplication application)
    {
        _context.JobApplications.Add(application);
        await _context.SaveChangesAsync();
    }

    public async Task<List<JobApplication>> GetByCandidateIdAsync(Guid candidateId)
    {
        return await _context.JobApplications
            .Where(a => a.CandidateId == candidateId)
            .ToListAsync();
    }

    public async Task<List<JobApplication>> GetByJobIdAsync(Guid jobId)
    {
        return await _context.JobApplications
            .Where(a => a.JobId == jobId)
            .ToListAsync();
    }

    public async Task<JobApplication?> GetByJobAndCandidateAsync(Guid jobId, Guid candidateId)
    {
        return await _context.JobApplications
            .FirstOrDefaultAsync(a =>
                a.JobId == jobId &&
                a.CandidateId == candidateId);
    }
}