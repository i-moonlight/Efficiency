using Efficiency.Data.DTO.Store;
using Efficiency.Services;
using Microsoft.AspNetCore.Mvc;

namespace Efficiency.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreController : ControllerBase
{
    private StoreService _service;

    public StoreController(StoreService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        IActionResult result = NoContent();

        ICollection<GetStoreDTO>? stores = _service.GetAll(skip, take);

        if (stores != null)
        {
            result = Ok(stores);
        }

        return result;
    }

    [HttpGet("{ID}")]
    public IActionResult GetStore(int StoreID)
    {
        IActionResult result = NotFound();

        GetStoreDTO? Store = _service.Get(StoreID);

        if (Store != null)
        {
            result = Ok(Store);
        }

        return result;
    }

    [HttpPost]
    public IActionResult CreateStore([FromBody] PostStoreDTO StoreDTO)
    {
        IActionResult result = StatusCode(500);

        GetStoreDTO? createdStore = _service.Post(StoreDTO);

        if (createdStore != null)
        {
            result = CreatedAtAction(
                nameof(GetStore),
                new { ID = createdStore.ID },
                createdStore
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult UpdateStore([FromBody] PutStoreDTO StoreDTO)
    {
        IActionResult result = NotFound("The informed Store was not found");

        bool updateSucceeded = _service.Put(StoreDTO);

        if (updateSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{ID}")]
    public IActionResult DeleteStore(int ID)
    {
        IActionResult result = NotFound("The informed Store was not found");

        bool deleteSucceeded = _service.Delete(ID);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }
}