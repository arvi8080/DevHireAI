using System.Security.Claims;
using DevHireAI.Application.DTOs.Resume;
using DevHireAI.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevHireAI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Candidate")]
public class ResumeController : ControllerBase
{
    private readonly IResumeService _resumeService;

    public ResumeController(IResumeService resumeService)
    {
        _resumeService = resumeService;
    }

    // POST: api/Resume/upload
    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromBody] UploadResumeRequest request)
    {
        var userId = Guid.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        await _resumeService.UploadResumeAsync(request, userId);

        return Ok(new
        {
            Message = "Resume uploaded successfully."
        });
    }

    // GET: api/Resume/me
    [HttpGet("me")]
    public async Task<IActionResult> GetMyResume()
    {
        var userId = Guid.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var resume = await _resumeService.GetMyResumeAsync(userId);

        if (resume == null)
            return NotFound(new
            {
                Message = "Resume not found."
            });

        return Ok(resume);
    }

    // DELETE: api/Resume
    [HttpDelete]
    public async Task<IActionResult> Delete()
    {
        var userId = Guid.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        await _resumeService.DeleteResumeAsync(userId);

        return Ok(new
        {
            Message = "Resume deleted successfully."
        });
    }
}