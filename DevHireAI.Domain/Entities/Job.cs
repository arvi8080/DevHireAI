namespace DevHireAI.Domain.Entities;

public class Job
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public string CompanyName { get; set; } = string.Empty;

    public decimal Salary { get; set; }

    public string Location { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foreign Key
    public Guid PostedByUserId { get; set; }
}