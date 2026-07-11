using DevHireAI.Application.DTOs.Job;
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
        return await _context.Jobs.FindAsync(id);
    }

    public async Task AddAsync(Job job)
    {
        _context.Jobs.Add(job);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Job job)
    {
        _context.Jobs.Remove(job);
        await _context.SaveChangesAsync();
    }

    public async Task<PagedResponse<Job>> SearchJobsAsync(JobSearchRequest request)
    {
        var query = _context.Jobs.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Title))
            query = query.Where(j => j.Title.Contains(request.Title));

        if (!string.IsNullOrWhiteSpace(request.CompanyName))
            query = query.Where(j => j.CompanyName.Contains(request.CompanyName));

        if (!string.IsNullOrWhiteSpace(request.Location))
            query = query.Where(j => j.Location.Contains(request.Location));

        if (request.MinSalary.HasValue)
            query = query.Where(j => j.Salary >= request.MinSalary.Value);

        if (request.MaxSalary.HasValue)
            query = query.Where(j => j.Salary <= request.MaxSalary.Value);

        var totalCount = await query.CountAsync();

        var jobs = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return new PagedResponse<Job>
        {
            Items = jobs,
            Page = request.Page,
            PageSize = request.PageSize,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling((double)totalCount / request.PageSize)
        };
    }
}