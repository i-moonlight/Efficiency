using AutoMapper;
using Efficiency.Data.DTO.Store;
using Efficiency.Models;

namespace Efficiency.Services;

public class StoreService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public StoreService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
}