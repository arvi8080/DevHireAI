using DevHireAI.Application.DTOs.JobApplication;
using DevHireAI.Application.Interfaces.Repositories;
using DevHireAI.Application.Interfaces.Services;

namespace DevHireAI.Infrastructure.Services;

public class JobApplicationService : IJobApplicationService
{
    private readonly IJobApplicationRepository _applicationRepository;

    public JobApplicationService(IJobApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }

    public async Task ApplyAsync(ApplyJobRequest request, Guid candidateId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<JobApplicationResponse>> GetMyApplicationsAsync(Guid candidateId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<JobApplicationResponse>> GetApplicationsByJobIdAsync(Guid jobId)
    {
        throw new NotImplementedException();
    }
}