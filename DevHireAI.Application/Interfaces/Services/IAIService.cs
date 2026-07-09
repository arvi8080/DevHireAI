using DevHireAI.Application.DTOs.AI;

namespace DevHireAI.Application.Interfaces.Services;

public interface IAIService
{
    Task<ResumeAnalysisResponse> AnalyzeResumeAsync(ResumeAnalysisRequest request);
}