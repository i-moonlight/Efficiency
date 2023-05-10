using Efficiency.Data.DTO.Result;
using Efficiency.Data.DTO.SellerResults;
using Efficiency.Data.Requests;
using Efficiency.Models.Enums;
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
    public IActionResult GetAllResults(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 0)
    {
        IActionResult result = NoContent();

        ICollection<GetResultDTO>? results = _resultService.GetAll(skip, take);

        if (results != null)
            result = Ok(results);

        return result;
    }

    [HttpGet("{resultID}")]
    public IActionResult GetResult(int resultID)
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
    public IActionResult PostResult([FromBody] PostResultDTO ResultDTO)
    {
        IActionResult result = StatusCode(500);

        GetResultDTO? createdResult = _resultService.Post(ResultDTO);

        if (createdResult != null)
        {
            result = CreatedAtAction(
                nameof(GetResult),
                new { resultID = createdResult.ID },
                createdResult
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult PutResult([FromBody] PutResultDTO ResultDTO)
    {
        IActionResult result = NotFound("Result not found");

        bool updateSucceeded = _resultService.Put(ResultDTO);

        if (updateSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{resultID}")]
    public IActionResult DeleteResult(int resultID)
    {
        IActionResult result = NotFound("Result not found");

        bool deleteSucceeded = _resultService.Delete(resultID);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpGet("seller/{sellerID}/date")]
    public IActionResult GetSellerResults(
        int sellerID,
        [FromQuery] int year = 0,
        [FromQuery] Quarter? quarter = null,
        [FromQuery] Month? month = null,
        [FromQuery] int day = 0
    )
    {
        IActionResult result = NotFound("No result found for seller/date");

        ICollection<GetSellerResultsDTO>? results = this._resultService.GetSellerResults(
            sellerID,
            year,
            quarter,
            month,
            day
        );

        if (results != null)
            result = Ok(results);

        return result;
    }

    [HttpPost("sellers/date")]
    public IActionResult GetBulkSellersResults(
        [FromBody] SellersArray sellersIDs,
        [FromQuery] int year = 0,
        [FromQuery] Quarter? quarter = null,
        [FromQuery] Month? month = null,
        [FromQuery] int day = 0
    )
    {
        IActionResult result = NotFound("No result found for seller/date");

        ICollection<GetSellerResultsDTO>? results = this._resultService.GetBulkSellersResults(
            sellersIDs.SellersIDs,
            year,
            quarter,
            month,
            day
        );

        if (results != null)
            result = Ok(results);

        return result;
    }
}