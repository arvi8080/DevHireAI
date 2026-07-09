namespace DevHireAI.Application.DTOs.Resume;

public class ResumeResponse
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string FileName { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public DateTime UploadedAt { get; set; }
}