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
    public IActionResult GetAllServices(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 0)
    {
        IActionResult result = NoContent();

        ICollection<GetServiceDTO>? services = _service.GetAll(skip, take);

        if (services != null)
            result = Ok(services);

        return result;
    }

    [HttpGet("{serviceID}")]
    public IActionResult GetService(int serviceID)
    {
        IActionResult result = NotFound();

        GetServiceDTO? service = _service.Get(serviceID);

        if (service != null)
            result = Ok(service);

        return result;
    }

    [HttpPost]
    public IActionResult PostService([FromBody] PostServiceDTO ServiceDTO)
    {
        IActionResult result = StatusCode(500);

        GetServiceDTO? service = _service.Post(ServiceDTO);

        if (service != null)
        {
            result = CreatedAtAction(
                nameof(GetService),
                new { serviceID = service.ID },
                service
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult PutService([FromBody] PutServiceDTO ServiceDTO)
    {
        IActionResult result = NotFound("The informed Financial Result was not found");

        bool updateSucceeded = _service.Put(ServiceDTO);

        if (updateSucceeded)
            result = NoContent();

        return result;
    }

    [HttpDelete("{serviceID}")]
    public IActionResult DeleteService(int serviceID)
    {
        IActionResult result = NotFound("The informed Financial Result was not found");

        bool deleteSucceeded = _service.Delete(serviceID);

        if (deleteSucceeded)
            result = NoContent();

        return result;
    }
}