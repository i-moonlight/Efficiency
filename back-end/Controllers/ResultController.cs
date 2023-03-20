using Efficiency.Data.DTO.Result;
using Efficiency.Services;
using Microsoft.AspNetCore.Mvc;

namespace Efficiency.Controllers;

[ApiController]
[Route("[controller]")]
public class ResultController : ControllerBase
{
    private ResultService _service;

    public ResultController(ResultService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] int skip=0,
        [FromQuery] int take=50)
    {
        IActionResult result = NoContent();

        ICollection<GetResultDTO>? results = _service.GetAll(skip, take);

        if (results != null)
        {
            result = Ok(results);
        }

        return result;
    }

    [HttpGet("{ID}")]
    public IActionResult Get(int ID)
    {
        IActionResult result = NotFound();

        GetResultDTO? Result = _service.Get(ID);

        if (Result != null)
        {
            result = Ok(Result);
        }

        return result;
    }

    [HttpPost]
    public IActionResult Post([FromBody] PostResultDTO ResultDTO)
    {
        IActionResult result = StatusCode(500);

        GetResultDTO? createdResult = _service.Post(ResultDTO);

        if (createdResult != null)
        {
            result = CreatedAtAction(
                nameof(Get),
                new { ID = createdResult.ID },
                createdResult
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult Put([FromBody] PutResultDTO ResultDTO)
    {
        IActionResult result = NotFound("This Result was not found");

        bool updateSucceeded = _service.Put(ResultDTO);

        if (updateSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{ID}")]
    public IActionResult Delete(int ID)
    {
        IActionResult result = NotFound("The Result was not found");

        bool deleteSucceeded = _service.Delete(ID);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }
}