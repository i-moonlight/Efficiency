using Efficiency.Data.DTO.SellerServiceResult;
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
    public IActionResult GetAll()
    {
        IActionResult result = NoContent();

        ICollection<GetServiceResultDTO>? DTO = _service.GetAll();

        if (DTO != null)
        {
            result = Ok(DTO);
        }

        return result;
    }

    [HttpGet("result/{resultID}/service/{serviceID}")]
    public IActionResult Get(int resultID, int serviceID)
    {
        IActionResult result = NotFound();

        GetServiceResultDTO? DTO = _service.Get(serviceID, resultID);

        if (DTO != null)
        {
            result = Ok(DTO);
        }

        return result;
    }

    [HttpGet("result/{resultID}/services")]
    public IActionResult GetResultServices(int resultID)
    {
        IActionResult result = NotFound();

        ICollection<GetServiceDTO>? DTO = _service.GetResultServices(resultID);

        if (DTO != null)
        {
            result = Ok(DTO);
        }

        return result;
    }

    [HttpPost]
    public IActionResult Post([FromBody] PostServiceResultDTO DTO)
    {
        IActionResult result = StatusCode(500);

        GetServiceResultDTO? serviceResult = _service.Post(DTO);

        if (serviceResult != null)
        {
            result = CreatedAtAction(
                nameof(Get),
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
    public IActionResult Put([FromBody] PutServiceResultDTO DTO)
    {
        IActionResult result = NotFound();

        bool updateSucceeded = _service.Put(DTO);

        if (updateSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("result/{resultID}/service/{serviceID}")]
    public IActionResult Delete(int resultID, int serviceID)
    {

        IActionResult result = NotFound();

        bool deleteSucceeded = _service.Delete(serviceID, resultID);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpPost("sellers/year/quarter/month/day")]
    public IActionResult GetBulkSellerServiceResult(
        [FromBody] GetSellersResults sellersIDs,
        [FromQuery] int year = 0,
        [FromQuery] int quarter = 0,
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