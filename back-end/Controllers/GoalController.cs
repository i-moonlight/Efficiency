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
    public IActionResult GetAllGoals(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 0)
    {
        IActionResult result = NoContent();

        ICollection<GetGoalDTO>? Goals = _service.GetAll(skip, take);

        if (Goals != null)
            result = Ok(Goals);

        return result;
    }

    [HttpGet("{goalID}")]
    public IActionResult GetGoal(int goalID)
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
    public IActionResult PostGoal([FromBody] PostGoalDTO GoalDTO)
    {
        IActionResult result = StatusCode(500);

        GetGoalDTO? createdGoal = _service.Post(GoalDTO);

        if (createdGoal != null)
        {
            result = CreatedAtAction(
                nameof(GetGoal),
                new { goalID = createdGoal.ID },
                createdGoal
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult PutGoal([FromBody] PutGoalDTO GoalDTO)
    {
        IActionResult result = NotFound("No goal found with the provided data");

        bool updateSucceeded = _service.Put(GoalDTO);

        if (updateSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{goalID}")]
    public IActionResult DeleteGoal(int goalID)
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