using System.Security.Claims;
using DevHireAI.Application.DTOs.Company;
using DevHireAI.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevHireAI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Recruiter")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    // POST: api/Company
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCompanyRequest request)
    {
        var ownerId = Guid.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        await _companyService.CreateCompanyAsync(request, ownerId);

        return Ok(new
        {
            Message = "Company created successfully."
        });
    }

    // GET: api/Company
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var companies = await _companyService.GetAllCompaniesAsync();

        return Ok(companies);
    }

    // GET: api/Company/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var company = await _companyService.GetCompanyByIdAsync(id);

        if (company == null)
            return NotFound(new
            {
                Message = "Company not found."
            });

        return Ok(company);
    }

    // DELETE: api/Company/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _companyService.DeleteCompanyAsync(id);

        return Ok(new
        {
            Message = "Company deleted successfully."
        });
    }
}