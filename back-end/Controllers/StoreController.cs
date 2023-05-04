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
        [FromQuery] int take = 50)
    {
        IActionResult result = NoContent();

        ICollection<GetStoreDTO>? stores = _storeService.GetAll(skip, take);

        if (stores != null)
        {
            result = Ok(stores);
        }

        return result;
    }

    [HttpGet("{storeID}")]
    public IActionResult GetStore(int storeID)
    {
        IActionResult result = NotFound();

        GetStoreDTO? Store = _storeService.Get(storeID);

        if (Store != null)
        {
            result = Ok(Store);
        }

        return result;
    }

    [HttpGet("{storeID}/users")]
    public IActionResult GetStoreUsers(int storeID)
    {
        IActionResult result = NotFound();

        ICollection<GetUserDTO>? users = _storeService.GetStoreUsers(storeID);

        if (users != null)
        {
            result = Ok(users);
        }

        return result;
    }

    [HttpGet("{storeID}/sellers")]
    public IActionResult GetStoreSellers(int storeID)
    {
        IActionResult result = NotFound();

        ICollection<GetSellerDTO>? sellers = _storeService.GetStoreSellers(storeID);

        if (sellers != null)
        {
            result = Ok(sellers);
        }

        return result;
    }

    [HttpGet("{storeID}/services")]
    public IActionResult GetStoreServices(int storeID)
    {
        IActionResult result = NotFound();

        ICollection<GetServiceDTO>? services = _storeService.GetStoreServices(storeID);

        if (services != null)
        {
            result = Ok(services);
        }

        return result;
    }

    [HttpGet("{storeID}/goals")]
    public IActionResult GetGoals(
        int storeID,
        [FromQuery] int? year = null,
        [FromQuery] int? quarter = null,
        [FromQuery] Month? month = null
    )
    {
        IActionResult result = NotFound();
        ICollection<GetGoalDTO>? goals = null;

        if (year == null)
            goals = _storeService.GetAllStoreGoals(storeID);
        else if (quarter != null)
            goals = _storeService.GetQuarterStoreGoals(storeID, ((int)year), ((int)quarter));
        else if (month != null)
            goals = _storeService.GetMonthStoreGoals(storeID, ((int)year), ((Month)month));
        else
            goals = _storeService.GetYearStoreGoals(storeID, ((int)year));

        if (goals != null)
        {
            result = Ok(goals);
        }

        return result;
    }

    [HttpGet("{storeID}/goals/year/{year}")]
    public IActionResult GetYearGoals(int storeID, int year)
    {
        string errorMessage = "We haven't found any goals from this store at this year. Check your input and try again.\n\nNote that we  do not allow the register of goals for a year that is bigger than the current one";
        IActionResult result = NotFound(errorMessage);

        if (year <= DateTime.Now.Year)
        {
            ICollection<GetGoalDTO>? goals = _storeService.GetYearStoreGoals(storeID, year);

            if (goals != null)
            {
                result = Ok(goals);
            }
        }

        return result;
    }

    [HttpGet("{storeID}/goals/year/{year}/quarter/{quarter}")]
    public IActionResult GetQuarterGoals(int storeID, int year, int quarter)
    {
        string errorMessage = "We haven't found any goals from this store at this quarter/year. Check your input and try again.\n\nNote that we  do not allow the register of goals for a year that is bigger than the current one";
        IActionResult result = NotFound(errorMessage);

        if (quarter >= 1 && quarter <= 4 && year <= DateTime.Now.Year)
        {
            ICollection<GetGoalDTO>? goals = _storeService.GetQuarterStoreGoals(storeID, year, quarter);

            if (goals != null)
            {
                result = Ok(goals);
            }
        }

        return result;
    }

    [HttpGet("{storeID}/goals/year/{year}/month/{month}")]
    public IActionResult GetMonthGoals(int storeID, int year, Month month)
    {
        int m = ((int)month);

        string errorMessage = "We haven't found any goals from this store at this month/year. Check your input and try again.\n\nNote that we do not allow the register of goals for a year that is bigger than the current one";
        IActionResult result = NotFound(errorMessage);

        if (m >= 1 && m <= 12 && year <= DateTime.Now.Year)
        {
            ICollection<GetGoalDTO>? goals = _storeService.GetMonthStoreGoals(storeID, year, month);

            if (goals != null)
            {
                result = Ok(goals);
            }
        }

        return result;
    }

    [HttpPost]
    public IActionResult CreateStore([FromBody] PostStoreDTO StoreDTO)
    {
        IActionResult result = StatusCode(500);

        GetStoreDTO? createdStore = _storeService.Post(StoreDTO);

        if (createdStore != null)
        {
            result = CreatedAtAction(
                nameof(GetStore),
                new { storeID = createdStore.ID },
                createdStore
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
        IActionResult result = NotFound("The informed Store was not found");

        bool deleteSucceeded = _storeService.Delete(storeID);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }
}