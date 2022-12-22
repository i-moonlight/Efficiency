using Efficiency.Data.DTO.Company;
using Efficiency.Services;
using Microsoft.AspNetCore.Mvc;

namespace Efficiency.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{
    private CompanyService _service;

    public CompanyController(CompanyService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        IActionResult result = NoContent();

        ICollection<GetCompanyDTO>? companies = _service.GetAll();

        if (companies != null)
        {
            result = Ok(companies);
        }

        return result;
    }
}