using DevHireAI.Application.DTOs.AI;
using DevHireAI.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevHireAI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AIController : ControllerBase
{
    private readonly IAIService _aiService;

    public AIController(IAIService aiService)
    {
        _aiService = aiService;
    }

    [Authorize]
    [HttpPost("analyze-resume")]
    public async Task<IActionResult> AnalyzeResume([FromBody] ResumeAnalysisRequest request)
    {
        var result = await _aiService.AnalyzeResumeAsync(request);
        return Ok(result);
    }
}