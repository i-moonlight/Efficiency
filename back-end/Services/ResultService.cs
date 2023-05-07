using AutoMapper;
using Efficiency.Data.DTO.Result;
using Efficiency.Data.DTO.SellerServiceResult;
using Efficiency.Models;

namespace Efficiency.Services;

public class ResultService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public ResultService(
        AppDbContext context,
        IMapper mapper
    )
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<GetResultDTO> GetAll(int skip, int take)
    {
        return _mapper.Map<ICollection<GetResultDTO>>(
            _context.Results?
                .Skip(skip)
                .Take(take)
                .ToList()
        );
    }

    public GetResultDTO? Get(int ID)
    {
        return _mapper.Map<GetResultDTO>(
            _context.Results?.FirstOrDefault(
                result => result.ID == ID
            )
        );
    }

    public GetResultDTO? Post(PostResultDTO ResultDTO)
    {
        GetResultDTO? result = null;
        Result? Result = _context.Results?.FirstOrDefault(
            result => result.Date.CompareTo(ResultDTO.Date) == 0
                    && result.SellerID == ResultDTO.SellerID
        );

        // if Result is null, it means that no result 
        // with the informed date, seller and service 
        // was found, meaning we can add it to the 
        // database with no duplicates
        if (Result == null)
        {
            Result = _mapper.Map<Result>(ResultDTO);
            _context.Results?.Add(Result);
            _context.SaveChanges();
            // POST Result -> POST Service -> POST ServicesResults
            result = _mapper.Map<GetResultDTO>(Result);
        }

        return result;
    }

    public bool Put(PutResultDTO ResultDTO)
    {
        bool result = false;

        Result? Result = _context.Results?.FirstOrDefault(
            result => result.ID == ResultDTO.ID
        );

        if (Result != null)
        {
            _mapper.Map(ResultDTO, Result);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    public bool Delete(int ID)
    {
        bool result = false;

        Result? Result = _context.Results?.FirstOrDefault(
            result => result.ID == ID
        );

        if (Result != null)
        {
            _context.Remove(Result);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }
}