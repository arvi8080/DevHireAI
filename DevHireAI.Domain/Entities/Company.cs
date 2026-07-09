namespace DevHireAI.Domain.Entities;

public class Company
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Website { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public Guid OwnerId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}