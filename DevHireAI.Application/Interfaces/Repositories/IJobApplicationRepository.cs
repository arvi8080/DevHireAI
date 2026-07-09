using DevHireAI.Domain.Entities;

namespace DevHireAI.Application.Interfaces.Repositories;

public interface IJobApplicationRepository
{
    Task AddAsync(JobApplication application);

    Task<List<JobApplication>> GetByCandidateIdAsync(Guid candidateId);

    Task<List<JobApplication>> GetByJobIdAsync(Guid jobId);

    Task<JobApplication?> GetByJobAndCandidateAsync(Guid jobId, Guid candidateId);
}