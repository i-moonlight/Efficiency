using Efficiency.Data.DTO.ServiceGoal;
using Efficiency.Services;
using Microsoft.AspNetCore.Mvc;

namespace Efficiency.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceGoalController : ControllerBase
{
    private ServiceGoalService _service { get; set; }

    public ServiceGoalController(ServiceGoalService service)
    {
        _service = service;
    }

    // TODO
    [HttpGet]
    public IActionResult GetAll()
    {
        IActionResult result = NoContent();

        ICollection<GetServiceGoalDTO>? DTO = _service.GetAll();

        if (DTO != null)
        {
            result = Ok(DTO);
        }

        return result;
    }

    [HttpGet("{goalID}/{serviceID}")]
    public IActionResult Get(int goalID, int serviceID)
    {
        IActionResult result = NotFound();

        GetServiceGoalDTO? DTO = _service.Get(serviceID, goalID);

        if (DTO != null)
        {
            result = Ok(DTO);
        }

        return result;
    }

    [HttpPost]
    public IActionResult Post([FromBody] PostServiceGoalDTO DTO)
    {
        IActionResult result = StatusCode(500);

        GetServiceGoalDTO? serviceGoal = _service.Post(DTO);

        if (serviceGoal != null)
        {
            result = CreatedAtAction(
                nameof(Get),
                new
                {
                    goalID = serviceGoal.Goal?.ID,
                    serviceID = serviceGoal.Service?.ID
                },
                serviceGoal
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult Put([FromBody] PutServiceGoalDTO DTO)
    {
        IActionResult result = NotFound();

        bool updateSucceeded = _service.Put(DTO);

        if (updateSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{goalID}/{serviceID}")]
    public IActionResult Delete(int goalID, int serviceID)
    {

        IActionResult result = NotFound();

        bool deleteSucceeded = _service.Delete(serviceID, goalID);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }
}