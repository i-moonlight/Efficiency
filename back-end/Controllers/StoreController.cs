using Efficiency.Data.DTO.Goal;
using Efficiency.Data.DTO.Seller;
using Efficiency.Data.DTO.Service;
using Efficiency.Data.DTO.Store;
using Efficiency.Models.Enums;
using Efficiency.Services;
using Microsoft.AspNetCore.Mvc;

namespace Efficiency.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreController : ControllerBase
{
    private StoreService _storeService;
    private SellerService _sellerService;
    private ServiceService _serviceService;
    private GoalService _goalService;

    public StoreController(StoreService storeService, SellerService sellerService, ServiceService serviceService, GoalService goalService)
    {
        _storeService = storeService;
        _sellerService = sellerService;
        _serviceService = serviceService;
        _goalService = goalService;
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

    [HttpGet("{ID}")]
    public IActionResult GetStore(int StoreID)
    {
        IActionResult result = NotFound();

        GetStoreDTO? Store = _storeService.Get(StoreID);

        if (Store != null)
        {
            result = Ok(Store);
        }

        return result;
    }

    [HttpGet("{ID}/sellers")]
    public IActionResult GetStoreSellers(int ID)
    {
        IActionResult result = NotFound();

        ICollection<GetSellerDTO>? sellers = _sellerService.GetStoreSellers(ID);

        if (sellers != null)
        {
            result = Ok(sellers);
        }

        return result;
    }

    [HttpGet("{ID}/services")]
    public IActionResult GetStoreServices(int ID)
    {
        IActionResult result = NotFound();

        ICollection<GetServiceDTO>? services = _serviceService.GetStoreServices(ID);

        if (services != null)
        {
            result = Ok(services);
        }

        return result;
    }

    [HttpGet("{ID}/goals")]
    public IActionResult GetAllTimeGoals(int ID)
    {
        IActionResult result = NotFound();

        ICollection<GetGoalDTO>? goals = _goalService.GetAllStoreGoals(ID);

        if (goals != null)
        {
            result = Ok(goals);
        }

        return result;
    }

    [HttpGet("{ID}/goals/year/{year}")]
    public IActionResult GetYearGoals(int ID, int year)
    {
        string errorMessage = "We haven't found any goals from this store at this year. Check your input and try again.\n\nNote that we  do not allow the register of goals for a year that is bigger than the current one";
        IActionResult result = NotFound(errorMessage);

        if (year <= DateTime.Now.Year)
        {
            ICollection<GetGoalDTO>? goals = _goalService.GetYearStoreGoals(ID, year);

            if (goals != null)
            {
                result = Ok(goals);
            }
        }

        return result;
    }

    [HttpGet("{ID}/goals/year/{year}/quarter/{quarter}")]
    public IActionResult GetQuarterGoals(int ID, int year, int quarter)
    {
        string errorMessage = "We haven't found any goals from this store at this quarter/year. Check your input and try again.\n\nNote that we  do not allow the register of goals for a year that is bigger than the current one";
        IActionResult result = NotFound(errorMessage);

        if (quarter >= 1 && quarter <= 4 && year <= DateTime.Now.Year)
        {
            ICollection<GetGoalDTO>? goals = _goalService.GetQuarterStoreGoals(ID, year, quarter);

            if (goals != null)
            {
                result = Ok(goals);
            }
        }

        return result;
    }

    [HttpGet("{ID}/goals/year/{year}/month/{month}")]
    public IActionResult GetQuarterGoals(int ID, int year, Month month)
    {
        int m = ((int)month);

        string errorMessage = "We haven't found any goals from this store at this month/year. Check your input and try again.\n\nNote that we do not allow the register of goals for a year that is bigger than the current one";
        IActionResult result = NotFound(errorMessage);

        if (m >= 1 && m <= 12 && year <= DateTime.Now.Year)
        {
            ICollection<GetGoalDTO>? goals = _goalService.GetMonthStoreGoals(ID, year, month);

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

        bool updateSucceeded = _storeService.Put(StoreDTO);

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

        bool deleteSucceeded = _storeService.Delete(ID);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }
}