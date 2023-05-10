using Efficiency.Data.DTO.Service;
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
    public IActionResult GetAllServicesGoals(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 0
    )
    {
        IActionResult result = NoContent();

        ICollection<GetServiceGoalDTO>? DTO = _service.GetAll(skip, take);

        if (DTO != null)
            result = Ok(DTO);

        return result;
    }

    [HttpGet("{goalID}/{serviceID}")]
    public IActionResult GetServiceGoal(int goalID, int serviceID)
    {
        IActionResult result = NotFound();

        GetServiceGoalDTO? DTO = _service.Get(serviceID, goalID);

        if (DTO != null)
            result = Ok(DTO);

        return result;
    }

    [HttpPost]
    public IActionResult PostServiceGoal([FromBody] PostServiceGoalDTO DTO)
    {
        IActionResult result = StatusCode(500);

        GetServiceGoalDTO? serviceGoal = _service.Post(DTO);

        if (serviceGoal != null)
        {
            result = CreatedAtAction(
                nameof(GetServiceGoal),
                new
                {
                    goalID = serviceGoal.GoalID,
                    serviceID = serviceGoal.ServiceID
                },
                serviceGoal
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult PutServiceGoal([FromBody] PutServiceGoalDTO DTO)
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
    public IActionResult DeleteServiceGoal(int goalID, int serviceID)
    {

        IActionResult result = NotFound();

        bool deleteSucceeded = _service.Delete(serviceID, goalID);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpGet("{goalID}/services")]
    public IActionResult GetGoalServices(int goalID)
    {
        IActionResult result = NotFound();

        ICollection<GetServiceDTO>? DTO = _service.GetGoalServices(goalID);

        if (DTO != null)
            result = Ok(DTO);

        return result;
    }
}