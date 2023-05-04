using Efficiency.Data.DTO.Result;
using Efficiency.Data.DTO.SellerServiceResult;
using Efficiency.Services;
using Microsoft.AspNetCore.Mvc;

namespace Efficiency.Controllers;

[ApiController]
[Route("[controller]")]
public class ResultController : ControllerBase
{
    private ResultService _resultService;

    public ResultController(ResultService resultService)
    {
        _resultService = resultService;
    }

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        IActionResult result = NoContent();

        ICollection<GetResultDTO>? results = _resultService.GetAll(skip, take);

        if (results != null)
        {
            result = Ok(results);
        }

        return result;
    }

    [HttpGet("{resultID}")]
    public IActionResult Get(int resultID)
    {
        IActionResult result = NotFound();

        GetResultDTO? Result = _resultService.Get(resultID);

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

        GetResultDTO? createdResult = _resultService.Post(ResultDTO);

        if (createdResult != null)
        {
            result = CreatedAtAction(
                nameof(Get),
                new { resultID = createdResult.ID },
                createdResult
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult Put([FromBody] PutResultDTO ResultDTO)
    {
        IActionResult result = NotFound("This Result was not found");

        bool updateSucceeded = _resultService.Put(ResultDTO);

        if (updateSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{resultID}")]
    public IActionResult Delete(int resultID)
    {
        IActionResult result = NotFound("The Result was not found");

        bool deleteSucceeded = _resultService.Delete(resultID);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }
}