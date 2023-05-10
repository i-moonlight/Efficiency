using Efficiency.Data.DTO.SellerResults;
using Efficiency.Data.DTO.Service;
using Efficiency.Data.DTO.ServiceResult;
using Efficiency.Data.Requests;
using Efficiency.Models.Enums;
using Efficiency.Services;
using Microsoft.AspNetCore.Mvc;

namespace Efficiency.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceResultController : ControllerBase
{
    private ServiceResultService _service { get; set; }

    public ServiceResultController(ServiceResultService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAllServicesResults(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 0
    )
    {
        IActionResult result = NoContent();

        ICollection<GetServiceResultDTO>? DTO = _service.GetAll(skip, take);

        if (DTO != null)
            result = Ok(DTO);

        return result;
    }

    [HttpGet("{resultID}/{serviceID}")]
    public IActionResult GetServiceResult(int resultID, int serviceID)
    {
        IActionResult result = NotFound();

        GetServiceResultDTO? DTO = _service.Get(serviceID, resultID);

        if (DTO != null)
            result = Ok(DTO);

        return result;
    }

    [HttpPost]
    public IActionResult PostServiceResult([FromBody] PostServiceResultDTO DTO)
    {
        IActionResult result = StatusCode(500);

        GetServiceResultDTO? serviceResult = _service.Post(DTO);

        if (serviceResult != null)
        {
            result = CreatedAtAction(
                nameof(GetServiceResult),
                new
                {
                    resultID = serviceResult.Result?.ID,
                    serviceID = serviceResult.Service?.ID
                },
                serviceResult
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult PutServiceResult([FromBody] PutServiceResultDTO DTO)
    {
        IActionResult result = NotFound();

        bool updateSucceeded = _service.Put(DTO);

        if (updateSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{resultID}/{serviceID}")]
    public IActionResult DeleteServiceResult(int resultID, int serviceID)
    {

        IActionResult result = NotFound();

        bool deleteSucceeded = _service.Delete(serviceID, resultID);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpGet("{resultID}/services")]
    public IActionResult GetResultServices(int resultID)
    {
        IActionResult result = NotFound();

        ICollection<GetServiceDTO>? DTO = _service.GetResultServices(resultID);

        if (DTO != null)
            result = Ok(DTO);

        return result;
    }


    [HttpPost("seller/{sellerID}")]
    public IActionResult GetSellerServiceResult(
        int sellerID,
        [FromQuery] int year = 0,
        [FromQuery] Quarter? quarter = null,
        [FromQuery] Month? month = null,
        [FromQuery] int day = 0
    )
    {
        string errorMessage = "No services results for the informed seller were found. Make sure you provided a correct date and a valid seller id";
        IActionResult result = NotFound(errorMessage);

        ICollection<GetSellerServiceResultDTO>? results = this._service.GetBulkSellerServiceResult(
            new List<int>(sellerID),
            year,
            quarter,
            month,
            day
        );

        if (results != null)
            result = Ok(results);

        return result;
    }

    [HttpPost("sellers")]
    public IActionResult GetBulkSellerServiceResult(
        [FromBody] SellersArray sellersIDs,
        [FromQuery] int year = 0,
        [FromQuery] Quarter? quarter = null,
        [FromQuery] Month? month = null,
        [FromQuery] int day = 0
    )
    {
        string errorMessage = "No services results for any of the informed sellers were found. Make sure you provided a correct date and valid sellers ids";
        IActionResult result = NotFound(errorMessage);

        ICollection<GetSellerServiceResultDTO>? results = this._service.GetBulkSellerServiceResult(
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