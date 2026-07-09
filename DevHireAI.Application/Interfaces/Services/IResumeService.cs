using DevHireAI.Application.DTOs.Resume;

namespace DevHireAI.Application.Interfaces.Services;

public interface IResumeService
{
    Task UploadResumeAsync(UploadResumeRequest request, Guid userId);
    Task<ResumeResponse?> GetMyResumeAsync(Guid userId);
    Task DeleteResumeAsync(Guid userId);
}