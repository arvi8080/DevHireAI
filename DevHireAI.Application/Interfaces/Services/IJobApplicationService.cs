using DevHireAI.Application.DTOs.JobApplication;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevHireAI.Application.Interfaces.Services
{
    public interface IJobApplicationService
    {
        Task ApplyAsync(ApplyJobRequest request, Guid candidateId);

        Task<List<JobApplicationResponse>> GetMyApplicationsAsync(Guid candidateId);

        Task<List<JobApplicationResponse>> GetApplicationsByJobIdAsync(Guid jobId);
    }
}
