using AutoMapper;
using Efficiency.Data.DTO.Seller;
using Efficiency.Data.DTO.SellerServiceResult;
using Efficiency.Models;

namespace Efficiency.Services;

public class SellerService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }
    private ServiceResultService _serviceResultService { get; set; }

    public SellerService(
        AppDbContext context,
        IMapper mapper,
        ServiceResultService serviceResultService
    )
    {
        _context = context;
        _mapper = mapper;
        _serviceResultService = serviceResultService;
    }

    public ICollection<GetSellerDTO> GetAll(int skip, int take)
    {
        return _mapper.Map<ICollection<GetSellerDTO>>(
            _context.Sellers?
                .Skip(skip)
                .Take(take)
                .ToList()
        );
    }

    public GetSellerDTO? Get(int ID)
    {
        return _mapper.Map<GetSellerDTO>(
            _context.Sellers?.FirstOrDefault(
                seller => seller.ID == ID
            )
        );
    }

    public GetSellerDTO? Post(PostSellerDTO SellerDTO)
    {
        GetSellerDTO? result = null;
        Seller? Seller = _context.Sellers?.FirstOrDefault(
            seller =>
                seller.RegistrationNumber == SellerDTO.RegistrationNumber
                && (
                    seller.FirstName != null
                    && SellerDTO.FirstName != null
                    && seller.FirstName
                        .ToUpper()
                        .Equals(SellerDTO.FirstName.ToUpper())
                )
        );

        if (Seller == null)
        {
            Seller = _mapper.Map<Seller>(SellerDTO);
            Seller.Active = true;
            _context.Sellers?.Add(Seller);
            _context.SaveChanges();
            result = _mapper.Map<GetSellerDTO>(Seller);
        }

        return result;
    }

    public bool Put(PutSellerDTO SellerDTO)
    {
        bool result = false;

        Seller? Seller = _context.Sellers?.FirstOrDefault(
            seller => seller.ID == SellerDTO.ID
        );

        if (Seller != null)
        {
            _mapper.Map(SellerDTO, Seller);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    public bool Delete(int ID)
    {
        bool result = false;

        Seller? Seller = _context.Sellers?.FirstOrDefault(
            seller => seller.ID == ID
        );

        if (Seller != null)
        {
            _context.Remove(Seller);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    public bool Deactivate(int ID)
    {

        bool result = false;

        Seller? Seller = _context.Sellers?.FirstOrDefault(
            seller => seller.ID == ID
        );

        if (Seller != null)
        {
            Seller.Active = false;
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    public ICollection<GetSellerDTO>? GetStoreSellers(int storeID)
    {
        return this._mapper.Map<ICollection<GetSellerDTO>>
        (
            from seller in this._context.Sellers
            where seller.StoreID == storeID
            select seller
        );
    }

    public ICollection<GetSellerServiceResultDTO>? GetSellersServicesResults(List<int> sellersIDs, DateOnly date)
    {
        return this._serviceResultService.GetSellersServicesResults(sellersIDs, date);
    }
}