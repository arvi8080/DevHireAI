namespace DevHireAI.Application.DTOs.AI;

public class ResumeAnalysisResponse
{
    public int MatchPercentage { get; set; }

    public List<string> MatchingSkills { get; set; } = new();

    public List<string> MissingSkills { get; set; } = new();

    public string Suggestion { get; set; } = string.Empty;
}