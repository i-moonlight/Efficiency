using AutoMapper;
using Efficiency.Data.DTO.Goal;
using Efficiency.Data.DTO.Seller;
using Efficiency.Data.DTO.Service;
using Efficiency.Data.DTO.Store;
using Efficiency.Data.DTO.User;
using Efficiency.Models;
using Efficiency.Models.Enums;

namespace Efficiency.Services;

public class StoreService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }
    private GoalService _goalService { get; set; }
    private UserService _userService { get; set; }
    private SellerService _sellerService { get; set; }
    private ServiceService _serviceService { get; set; }

    public StoreService(
        AppDbContext context,
        IMapper mapper,
        GoalService goalService,
        UserService userService,
        SellerService sellerService,
        ServiceService serviceService
    )
    {
        _context = context;
        _mapper = mapper;
        _goalService = goalService;
        _sellerService = sellerService;
        _serviceService = serviceService;
        _userService = userService;
    }

    public ICollection<GetStoreDTO> GetAll(int skip, int take)
    {
        return _mapper.Map<ICollection<GetStoreDTO>>(
            _context.Stores?
                .Skip(skip)
                .Take(take)
                .ToList()
        );
    }

    public GetStoreDTO? Get(int ID)
    {
        return _mapper.Map<GetStoreDTO>(
            _context.Stores?.FirstOrDefault(
                store => store.ID == ID
            )
        );
    }

    public GetStoreDTO? Post(PostStoreDTO StoreDTO)
    {
        GetStoreDTO? result = null;
        Store? Store = _context.Stores?.FirstOrDefault(
            store => store.Name != null
                && StoreDTO.Name != null
                && store.Name.ToUpper().Equals(StoreDTO.Name.ToUpper())
        );

        if (Store == null)
        {
            Store = _mapper.Map<Store>(StoreDTO);
            _context.Stores?.Add(Store);
            _context.SaveChanges();
            result = _mapper.Map<GetStoreDTO>(Store);
        }

        return result;
    }

    public bool Put(PutStoreDTO StoreDTO)
    {
        bool result = false;

        Store? Store = _context.Stores?.FirstOrDefault(
            store => store.ID == StoreDTO.ID
        );

        if (Store != null)
        {
            _mapper.Map(StoreDTO, Store);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    public bool Delete(int ID)
    {
        bool result = false;

        Store? Store = _context.Stores?.FirstOrDefault(
            store => store.ID == ID
        );

        if (Store != null)
        {
            _context.Remove(Store);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    public ICollection<GetGoalDTO>? GetAllStoreGoals(int storeID)
    {
        return this._goalService.GetAllStoreGoals(storeID);
    }

    public ICollection<GetGoalDTO>? GetYearStoreGoals(int storeID, int year)
    {
        return this._goalService.GetYearStoreGoals(storeID, year);
    }

    public ICollection<GetGoalDTO>? GetQuarterStoreGoals(int storeID, int year, int quarter)
    {
        return this._goalService.GetQuarterStoreGoals(storeID, year, quarter);
    }


    public ICollection<GetGoalDTO>? GetMonthStoreGoals(int storeID, int year, Month month)
    {
        return this._goalService.GetMonthStoreGoals(storeID, year, month);
    }

    public ICollection<GetSellerDTO>? GetStoreSellers(int storeID)
    {
        return this._sellerService.GetStoreSellers(storeID);
    }

    public ICollection<GetServiceDTO>? GetStoreServices(int storeID)
    {
        return this._serviceService.GetStoreServices(storeID);
    }

    public ICollection<GetUserDTO>? GetStoreUsers(int storeID)
    {
        return this._userService.GetStoreUsers(storeID);
    }
}
