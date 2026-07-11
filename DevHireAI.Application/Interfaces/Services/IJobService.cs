using DevHireAI.Application.DTOs.Job;

namespace DevHireAI.Application.Interfaces.Services;

public interface IJobService
{
    Task<List<JobResponse>> GetAllJobsAsync();

    Task<JobResponse?> GetJobByIdAsync(Guid id);

    Task CreateJobAsync(CreateJobRequest request);

    Task DeleteJobAsync(Guid id);

    Task<PagedResponse<JobResponse>> SearchJobsAsync(JobSearchRequest request);
}