using Efficiency.Data.DTO.Employee;
using Efficiency.Services;
using Microsoft.AspNetCore.Mvc;

namespace Efficiency.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private EmployeeService _service;

    public EmployeeController(EmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] int skip=0,
        [FromQuery] int take=50)
    {
        IActionResult result = NoContent();

        ICollection<GetEmployeeDTO>? employees = _service.GetAll(skip, take);

        if (employees != null)
        {
            result = Ok(employees);
        }

        return result;
    }

    [HttpGet("{registrationNumber}")]
    public IActionResult Get(int registrationNumber)
    {
        IActionResult result = NotFound();

        GetEmployeeDTO? Employee = _service.GetAll(registrationNumber);

        if (Employee != null)
        {
            result = Ok(Employee);
        }

        return result;
    }

    [HttpPost]
    public IActionResult Post([FromBody] PostEmployeeDTO EmployeeDTO)
    {
        IActionResult result = StatusCode(500);

        GetEmployeeDTO? createdEmployee = _service.Post(EmployeeDTO);

        if (createdEmployee != null)
        {
            result = CreatedAtAction(
                nameof(Get),
                new { registrationNumber = createdEmployee.RegistrationNumber },
                createdEmployee
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult Put([FromBody] PutEmployeeDTO EmployeeDTO)
    {
        IActionResult result = NotFound("The informed Employee was not found");

        bool updateSucceeded = _service.Put(EmployeeDTO);

        if (updateSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{registrationNumber}")]
    public IActionResult Delete(int registrationNumber)
    {
        IActionResult result = NotFound("The informed Employee was not found");

        bool deleteSucceeded = _service.Delete(registrationNumber);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }
}