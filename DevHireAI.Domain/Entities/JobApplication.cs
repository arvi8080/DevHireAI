namespace DevHireAI.Domain.Entities;

public class JobApplication
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid JobId { get; set; }

    public Guid CandidateId { get; set; }

    public DateTime AppliedAt { get; set; } = DateTime.UtcNow;

    public string Status { get; set; } = "Pending";
}