using Efficiency.Data.DTO.ServiceResult;
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

    // TODO
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

    [HttpGet("{ResultID}/{serviceID}")]
    public IActionResult Get(int ResultID, int serviceID)
    {
        IActionResult result = NotFound();

        GetServiceResultDTO? DTO = _service.Get(serviceID, ResultID);

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

    [HttpDelete("{ResultID}/{serviceID}")]
    public IActionResult Delete(int ResultID, int serviceID)
    {

        IActionResult result = NotFound();

        bool deleteSucceeded = _service.Delete(serviceID, ResultID);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }
}