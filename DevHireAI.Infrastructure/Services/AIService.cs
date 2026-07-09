using DevHireAI.Application.DTOs.AI;
using DevHireAI.Application.Interfaces.Services;

namespace DevHireAI.Infrastructure.Services;

public class AIService : IAIService
{
    public Task<ResumeAnalysisResponse> AnalyzeResumeAsync(ResumeAnalysisRequest request)
    {
        var resume = request.ResumeText.ToLower();
        var job = request.JobDescription.ToLower();

        var skills = new List<string>
        {
            "c#",
            ".net",
            "asp.net",
            "sql",
            "entity framework",
            "jwt",
            "docker",
            "kubernetes",
            "redis",
            "rabbitmq",
            "microservices",
            "azure",
            "git",
            "github"
        };

        var matchingSkills = new List<string>();
        var missingSkills = new List<string>();

        foreach (var skill in skills)
        {
            if (resume.Contains(skill) && job.Contains(skill))
            {
                matchingSkills.Add(skill);
            }
            else if (job.Contains(skill))
            {
                missingSkills.Add(skill);
            }
        }

        int totalRequired = matchingSkills.Count + missingSkills.Count;

        int percentage = totalRequired == 0
            ? 100
            : (matchingSkills.Count * 100) / totalRequired;

        return Task.FromResult(new ResumeAnalysisResponse
        {
            MatchPercentage = percentage,
            MatchingSkills = matchingSkills,
            MissingSkills = missingSkills,
            Suggestion = percentage >= 80
                ? "Excellent match for this job."
                : percentage >= 60
                    ? "Good match. Improve the missing skills."
                    : "Consider learning the missing skills before applying."
        });
    }
}