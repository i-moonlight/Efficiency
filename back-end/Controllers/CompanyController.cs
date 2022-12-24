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
    public IActionResult GetAll(
        [FromQuery] int skip=0,
        [FromQuery] int take=50)
    {
        IActionResult result = NoContent();

        ICollection<GetCompanyDTO>? companies = _service.GetAll(skip, take);

        if (companies != null)
        {
            result = Ok(companies);
        }

        return result;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        IActionResult result = NotFound();

        GetCompanyDTO? company = _service.Get(id);

        if (company != null)
        {
            result = Ok(company);
        }

        return result;
    }

    [HttpPost]
    public IActionResult Post([FromBody] PostCompanyDTO companyDTO)
    {
        IActionResult result = StatusCode(500);

        GetCompanyDTO? createdCompany = _service.Post(companyDTO);

        if (createdCompany != null)
        {
            result = CreatedAtAction(
                nameof(Get),
                new { id = createdCompany.ID },
                createdCompany
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult Put([FromBody] PutCompanyDTO companyDTO)
    {
        IActionResult result = NotFound("The informed company was not found");

        bool updateSucceeded = _service.Put(companyDTO);

        if (updateSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        IActionResult result = NotFound("The informed company was not found");

        bool deleteSucceeded = _service.Delete(id);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }
}