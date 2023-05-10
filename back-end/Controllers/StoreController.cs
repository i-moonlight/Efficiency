using Efficiency.Data.DTO.Goal;
using Efficiency.Data.DTO.Seller;
using Efficiency.Data.DTO.Service;
using Efficiency.Data.DTO.Store;
using Efficiency.Data.DTO.User;
using Efficiency.Models.Enums;
using Efficiency.Services;
using Microsoft.AspNetCore.Mvc;

namespace Efficiency.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreController : ControllerBase
{
    private StoreService _storeService;

    public StoreController(StoreService storeService)
    {
        _storeService = storeService;
    }

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 0)
    {
        IActionResult result = NoContent();

        ICollection<GetStoreDTO>? stores = _storeService.GetAll(skip, take);

        if (stores != null)
            result = Ok(stores);

        return result;
    }

    [HttpGet("{storeID}")]
    public IActionResult GetStore(int storeID)
    {
        IActionResult result = NotFound("Store not found");

        GetStoreDTO? store = _storeService.Get(storeID);

        if (store != null)
            result = Ok(store);

        return result;
    }

    [HttpPost]
    public IActionResult CreateStore([FromBody] PostStoreDTO StoreDTO)
    {
        IActionResult result = StatusCode(500);

        GetStoreDTO? store = _storeService.Post(StoreDTO);

        if (store != null)
        {
            result = CreatedAtAction(
                nameof(GetStore),
                new { storeID = store.ID },
                store
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult UpdateStore([FromBody] PutStoreDTO StoreDTO)
    {
        IActionResult result = NotFound("Store not found");

        bool updateSucceeded = _storeService.Put(StoreDTO);

        if (updateSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{storeID}")]
    public IActionResult DeleteStore(int storeID)
    {
        IActionResult result = NotFound("Store not found");

        bool deleteSucceeded = _storeService.Delete(storeID);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpGet("{storeID}/users")]
    public IActionResult GetStoreUsers(int storeID)
    {
        IActionResult result = NotFound();

        ICollection<GetUserDTO>? users = _storeService.GetStoreUsers(storeID);

        if (users != null)
            result = Ok(users);

        return result;
    }

    [HttpGet("{storeID}/sellers")]
    public IActionResult GetStoreSellers(int storeID)
    {
        IActionResult result = NotFound();

        ICollection<GetSellerDTO>? sellers = _storeService.GetStoreSellers(storeID);

        if (sellers != null)
            result = Ok(sellers);

        return result;
    }

    [HttpGet("{storeID}/services")]
    public IActionResult GetStoreServices(int storeID)
    {
        IActionResult result = NotFound();

        ICollection<GetServiceDTO>? services = _storeService.GetStoreServices(storeID);

        if (services != null)
            result = Ok(services);

        return result;
    }

    [HttpGet("{storeID}/goals")]
    public IActionResult GetGoals(
        int storeID,
        [FromQuery] int year = 0,
        [FromQuery] Quarter? quarter = null,
        [FromQuery] Month? month = null
    )
    {
        ICollection<GetGoalDTO>? goals = null;

        if (year == 0)
            goals = _storeService.GetAllStoreGoals(storeID);
        else if (month != null)
            goals = _storeService.GetMonthStoreGoals(storeID, year, ((Month)month));
        else if (quarter != null)
            goals = _storeService.GetQuarterStoreGoals(storeID, year, ((int)quarter));
        else
            goals = _storeService.GetYearStoreGoals(storeID, year);

        return goals != null ? Ok(goals) : NotFound();
    }
}