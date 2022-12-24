using Efficiency.Data.DTO.EmployeeFinancialResult;
using Efficiency.Services;
using Microsoft.AspNetCore.Mvc;

namespace Efficiency.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeFinancialResultController : ControllerBase
{
    private EmployeeFinancialResultService _service;

    public EmployeeFinancialResultController(EmployeeFinancialResultService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] int skip=0,
        [FromQuery] int take=50)
    {
        IActionResult result = NoContent();

        ICollection<GetEmployeeFinancialResultDTO>? employeeFinancialResults = _service.GetAll(skip, take);

        if (employeeFinancialResults != null)
        {
            result = Ok(employeeFinancialResults);
        }

        return result;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        IActionResult result = NotFound();

        GetEmployeeFinancialResultDTO? employeeFinancialResult = _service.Get(id);

        if (employeeFinancialResult != null)
        {
            result = Ok(employeeFinancialResult);
        }

        return result;
    }

    [HttpPost]
    public IActionResult Post([FromBody] PostEmployeeFinancialResultDTO employeeFinancialResultDTO)
    {
        IActionResult result = StatusCode(500);

        GetEmployeeFinancialResultDTO? createdEmployeeFinancialResult = _service.Post(employeeFinancialResultDTO);

        if (createdEmployeeFinancialResult != null)
        {
            result = CreatedAtAction(
                nameof(Get),
                new { id = createdEmployeeFinancialResult.ID },
                createdEmployeeFinancialResult
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult Put([FromBody] PutEmployeeFinancialResultDTO employeeFinancialResultDTO)
    {
        IActionResult result = NotFound("The informed EmployeeFinancialResult was not found");

        bool updateSucceeded = _service.Put(employeeFinancialResultDTO);

        if (updateSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        IActionResult result = NotFound("The informed EmployeeFinancialResult was not found");

        bool deleteSucceeded = _service.Delete(id);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }
}