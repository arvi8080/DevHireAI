using DevHireAI.Application.DTOs.Job;
using DevHireAI.Application.Interfaces.Repositories;
using DevHireAI.Application.Interfaces.Services;
using DevHireAI.Domain.Entities;

namespace DevHireAI.Infrastructure.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;

    public JobService(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task<List<JobResponse>> GetAllJobsAsync()
    {
        var jobs = await _jobRepository.GetAllAsync();

        return jobs.Select(job => new JobResponse
        {
            Id = job.Id,
            Title = job.Title,
            Description = job.Description,
            CompanyName = job.CompanyName,
            Location = job.Location,
            Salary = job.Salary,
            CreatedAt = job.CreatedAt
        }).ToList();
    }

    public async Task<JobResponse?> GetJobByIdAsync(Guid id)
    {
        var job = await _jobRepository.GetByIdAsync(id);

        if (job == null)
            return null;

        return new JobResponse
        {
            Id = job.Id,
            Title = job.Title,
            Description = job.Description,
            CompanyName = job.CompanyName,
            Location = job.Location,
            Salary = job.Salary,
            CreatedAt = job.CreatedAt
        };
    }

    public async Task CreateJobAsync(CreateJobRequest request)
    {
        var job = new Job
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            CompanyName = request.CompanyName,
            Location = request.Location,
            Salary = request.Salary,
            CreatedAt = DateTime.UtcNow
        };

        await _jobRepository.AddAsync(job);
    }

    public async Task DeleteJobAsync(Guid id)
    {
        var job = await _jobRepository.GetByIdAsync(id);

        if (job == null)
            throw new Exception("Job not found.");

        await _jobRepository.DeleteAsync(job);
    }
}