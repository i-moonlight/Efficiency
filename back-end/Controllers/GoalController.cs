using Efficiency.Data.DTO.Goal;
using Efficiency.Services;
using Microsoft.AspNetCore.Mvc;

namespace Efficiency.Controllers;

[ApiController]
[Route("[controller]")]
public class GoalController : ControllerBase
{
    private GoalService _service;

    public GoalController(GoalService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        IActionResult result = NoContent();

        ICollection<GetGoalDTO>? Goals = _service.GetAll(skip, take);

        if (Goals != null)
        {
            result = Ok(Goals);
        }

        return result;
    }

    [HttpGet("{goalID}")]
    public IActionResult Get(int goalID)
    {
        IActionResult result = NotFound();

        GetGoalDTO? Goal = _service.Get(goalID);

        if (Goal != null)
        {
            result = Ok(Goal);
        }

        return result;
    }

    [HttpPost]
    public IActionResult Post([FromBody] PostGoalDTO GoalDTO)
    {
        IActionResult result = StatusCode(500);

        GetGoalDTO? createdGoal = _service.Post(GoalDTO);

        if (createdGoal != null)
        {
            result = CreatedAtAction(
                nameof(Get),
                new { goalID = createdGoal.ID },
                createdGoal
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult Put([FromBody] PutGoalDTO GoalDTO)
    {
        IActionResult result = NotFound("The informed Goal was not found");

        bool updateSucceeded = _service.Put(GoalDTO);

        if (updateSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{goalID}")]
    public IActionResult Delete(int goalID)
    {
        IActionResult result = NotFound("The informed Goal was not found");

        bool deleteSucceeded = _service.Delete(goalID);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }
}