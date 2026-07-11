using DevHireAI.Application.DTOs.Job;
using DevHireAI.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace DevHireAI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;

    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var jobs = await _jobService.GetAllJobsAsync();
        return Ok(jobs);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var job = await _jobService.GetJobByIdAsync(id);

        if (job == null)
            return NotFound(new { Message = "Job not found." });

        return Ok(job);
    }


    [Authorize(Roles = "Recruiter")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateJobRequest request)
    {
        await _jobService.CreateJobAsync(request);

        return Ok(new
        {
            Message = "Job created successfully."
        });
    }

    [Authorize(Roles = "Recruiter")]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _jobService.DeleteJobAsync(id);

        return Ok(new { Message = "Job deleted successfully." });
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchJobs([FromQuery] JobSearchRequest request)
    {
        var result = await _jobService.SearchJobsAsync(request);
        return Ok(result);
    }


}