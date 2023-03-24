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
    // [HttpGet]
    // public IActionResult GetAll(){}
    // [HttpGet("{ID}")]
    // public IActionResult Get(int ID){}
    // [HttpPost]
    // public IActionResult Post([FromBody] PostServiceResultDTO serviceResultDTO){}
    // [HttpPut]
    // public IActionResult Put([FromBody] PutServiceResultDTO serviceResultDTO){}
    // [HttpDelete("{ID}")]
    // public IActionResult Delete(int ID){}
}