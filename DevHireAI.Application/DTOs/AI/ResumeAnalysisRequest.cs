namespace DevHireAI.Application.DTOs.AI;

public class ResumeAnalysisRequest
{
    public string ResumeText { get; set; } = string.Empty;

    public string JobDescription { get; set; } = string.Empty;
}