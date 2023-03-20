using Efficiency.Data.DTO.Service;
using Efficiency.Services;
using Microsoft.AspNetCore.Mvc;

namespace Efficiency.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceController : ControllerBase
{
    private ServiceService _service;

    public ServiceController(ServiceService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] int skip=0,
        [FromQuery] int take=50)
    {
        IActionResult result = NoContent();

        ICollection<GetServiceDTO>? fresults = _service.GetAll(skip, take);

        if (fresults != null)
        {
            result = Ok(fresults);
        }

        return result;
    }

    [HttpGet("{ID}")]
    public IActionResult Get(int ID)
    {
        IActionResult result = NotFound();

        GetServiceDTO? Service = _service.Get(ID);

        if (Service != null)
        {
            result = Ok(Service);
        }

        return result;
    }

    [HttpPost]
    public IActionResult Post([FromBody] PostServiceDTO ServiceDTO)
    {
        IActionResult result = StatusCode(500);

        GetServiceDTO? createdService = _service.Post(ServiceDTO);

        if (createdService != null)
        {
            result = CreatedAtAction(
                nameof(Get),
                new { ID = createdService.ID },
                createdService
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult Put([FromBody] PutServiceDTO ServiceDTO)
    {
        IActionResult result = NotFound("The informed Financial Result was not found");

        bool updateSucceeded = _service.Put(ServiceDTO);

        if (updateSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{ID}")]
    public IActionResult Delete(int ID)
    {
        IActionResult result = NotFound("The informed Financial Result was not found");

        bool deleteSucceeded = _service.Delete(ID);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }
}