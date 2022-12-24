using Efficiency.Data.DTO.FinancialService;
using Efficiency.Services;
using Microsoft.AspNetCore.Mvc;

namespace Efficiency.Controllers;

[ApiController]
[Route("[controller]")]
public class FinancialServiceController : ControllerBase
{
    private FinancialServiceService _service;

    public FinancialServiceController(FinancialServiceService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] int skip=0,
        [FromQuery] int take=50)
    {
        IActionResult result = NoContent();

        ICollection<GetFinancialServiceDTO>? fresults = _service.GetAll(skip, take);

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

        GetFinancialServiceDTO? FinancialService = _service.Get(id);

        if (FinancialService != null)
        {
            result = Ok(FinancialService);
        }

        return result;
    }

    [HttpPost]
    public IActionResult Post([FromBody] PostFinancialServiceDTO FinancialServiceDTO)
    {
        IActionResult result = StatusCode(500);

        GetFinancialServiceDTO? createdFinancialService = _service.Post(FinancialServiceDTO);

        if (createdFinancialService != null)
        {
            result = CreatedAtAction(
                nameof(Get),
                new { id = createdFinancialService.Id },
                createdFinancialService
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult Put([FromBody] PutFinancialServiceDTO FinancialServiceDTO)
    {
        IActionResult result = NotFound("The informed Financial Result was not found");

        bool updateSucceeded = _service.Put(FinancialServiceDTO);

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