using Efficiency.Data.DTO.FinancialResultFinancialService;
using Efficiency.Services;
using Microsoft.AspNetCore.Mvc;

namespace Efficiency.Controllers;

[ApiController]
[Route("[controller]")]
public class FinancialResultFinancialServiceController : ControllerBase
{
    private FinancialResultFinancialServiceService _service;

    public FinancialResultFinancialServiceController(FinancialResultFinancialServiceService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] int skip=0,
        [FromQuery] int take=50)
    {
        IActionResult result = NoContent();

        ICollection<GetFinancialResultFinancialServiceDTO>? fresults = _service.GetAll(skip, take);

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

        GetFinancialResultFinancialServiceDTO? FinancialResultFinancialService = _service.Get(id);

        if (FinancialResultFinancialService != null)
        {
            result = Ok(FinancialResultFinancialService);
        }

        return result;
    }

    [HttpPost]
    public IActionResult Post([FromBody] PostFinancialResultFinancialServiceDTO FinancialResultFinancialServiceDTO)
    {
        IActionResult result = StatusCode(500);

        GetFinancialResultFinancialServiceDTO? createdFinancialResultFinancialService = _service.Post(FinancialResultFinancialServiceDTO);

        if (createdFinancialResultFinancialService != null)
        {
            result = CreatedAtAction(
                nameof(Get),
                new { id = createdFinancialResultFinancialService.ID },
                createdFinancialResultFinancialService
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult Put([FromBody] PutFinancialResultFinancialServiceDTO FinancialResultFinancialServiceDTO)
    {
        IActionResult result = NotFound("The informed Financial Result was not found");

        bool updateSucceeded = _service.Put(FinancialResultFinancialServiceDTO);

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