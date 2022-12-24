using AutoMapper;
using Efficiency.Data.DTO.FinancialService;
using Efficiency.Models;

namespace Efficiency.Services;

public class FinancialServiceService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public FinancialServiceService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<GetFinancialServiceDTO> GetAll(int skip, int take)
    {
        return _mapper.Map<ICollection<GetFinancialServiceDTO>>(
            _context.FinancialServices?
                .Skip(skip)
                .Take(take)
                .ToList()
        );
    }

    public GetFinancialServiceDTO? Get(int id)
    {
        return _mapper.Map<GetFinancialServiceDTO>(
            _context.FinancialServices?.FirstOrDefault(
                fr => fr.Id == id
            )
        );
    }

    public GetFinancialServiceDTO? Post(PostFinancialServiceDTO financialServiceDTO)
    {
        GetFinancialServiceDTO? result = null;
        FinancialService financialService = _mapper.Map<FinancialService>(financialServiceDTO);

        if (!CheckExistingFinancialServiceByName(financialService))
        {
            _context.FinancialServices?.Add(financialService);
            _context.SaveChanges();
            result = _mapper.Map<GetFinancialServiceDTO>(financialService);
        }

        return result;
    }

    public bool Put(PutFinancialServiceDTO financialServiceDTO)
    {
        bool result = false;

        FinancialService? financialService = _context.FinancialServices?.FirstOrDefault(
            fr => fr.Id == financialServiceDTO.Id
        );

        if (financialService != null)
        {
            _mapper.Map(financialServiceDTO, financialService);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    public bool Delete(int ID)
    {
        bool result = false;
        
        FinancialService? financialService = _context.FinancialServices?.FirstOrDefault(
            fr => fr.Id == ID
        );

        if (financialService != null)
        {
            _context.Remove(financialService);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    private bool CheckExistingFinancialServiceByName(FinancialService financialService)
    {
        bool result = false;

        if (_context.FinancialServices != null)
        {
            var financialServices = _context.FinancialServices.ToList();
            foreach (var fService in financialServices)
            {
                if (!result && fService.Name != null && financialService.Name != null)
                {
                    result = (fService.Name.ToUpper().Equals(financialService.Name.ToUpper()));
                }
            }
            System.Console.WriteLine(result);
        }

        return result;
    }
}