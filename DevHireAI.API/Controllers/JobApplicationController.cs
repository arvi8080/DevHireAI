using DevHireAI.Application.DTOs.JobApplication;
using DevHireAI.Application.Interfaces.Services;
using DevHireAI.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DevHireAI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class JobApplicationController : ControllerBase
{
    private readonly IJobApplicationService _jobApplicationService;

    public JobApplicationController(IJobApplicationService jobApplicationService)
    {
        _jobApplicationService = jobApplicationService;
    }

    // POST: api/JobApplication/apply
    [HttpPost("apply")]
    public async Task<IActionResult> Apply([FromBody] ApplyJobRequest request)
    {
        var candidateId = Guid.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        await _jobApplicationService.ApplyAsync(request, candidateId);

        return Ok(new
        {
            Message = "Application submitted successfully."
        });
    }

    // GET: api/JobApplication/my
    [HttpGet("my")]
    public async Task<IActionResult> GetMyApplications()
    {
        var candidateId = Guid.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var applications = await _jobApplicationService.GetMyApplicationsAsync(candidateId);

        return Ok(applications);
    }

    // GET: api/JobApplication/job/{jobId}
    [HttpGet("job/{jobId:guid}")]
    public async Task<IActionResult> GetApplicationsByJob(Guid jobId)
    {
        var applications = await _jobApplicationService.GetApplicationsByJobIdAsync(jobId);

        return Ok(applications);
    }
}