using Efficiency.Data.DTO.FinancialResult;
using Efficiency.Services;
using Microsoft.AspNetCore.Mvc;

namespace Efficiency.Controllers;

[ApiController]
[Route("[controller]")]
public class FinancialResultController : ControllerBase
{
    private FinancialResultService _service;

    public FinancialResultController(FinancialResultService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] int skip=0,
        [FromQuery] int take=50)
    {
        IActionResult result = NoContent();

        ICollection<GetFinancialResultDTO>? fresults = _service.GetAll(skip, take);

        if (fresults != null)
        {
            result = Ok(fresults);
        }

        return result;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        IActionResult result = NotFound();

        GetFinancialResultDTO? financialResult = _service.GetAll(id);

        if (financialResult != null)
        {
            result = Ok(financialResult);
        }

        return result;
    }

    [HttpPost]
    public IActionResult Post([FromBody] PostFinancialResultDTO financialResultDTO)
    {
        IActionResult result = StatusCode(500);

        GetFinancialResultDTO? createdFinancialResult = _service.Post(financialResultDTO);

        if (createdFinancialResult != null)
        {
            result = CreatedAtAction(
                nameof(Get),
                new { id = createdFinancialResult.ID },
                createdFinancialResult
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult Put([FromBody] PutFinancialResultDTO financialResultDTO)
    {
        IActionResult result = NotFound("The informed Financial Result was not found");

        bool updateSucceeded = _service.Put(financialResultDTO);

        if (updateSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        IActionResult result = NotFound("The informed Financial Result was not found");

        bool deleteSucceeded = _service.Delete(id);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }
}