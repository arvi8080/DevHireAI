namespace DevHireAI.Application.DTOs.Job;

public class JobSearchRequest
{
    public string? Title { get; set; }

    public string? CompanyName { get; set; }

    public string? Location { get; set; }

    public decimal? MinSalary { get; set; }

    public decimal? MaxSalary { get; set; }

    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 10;
}