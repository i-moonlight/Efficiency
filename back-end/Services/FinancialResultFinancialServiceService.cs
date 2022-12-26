using AutoMapper;
using Efficiency.Data.DTO.FinancialResultFinancialService;
using Efficiency.Models;

namespace Efficiency.Services;

public class FinancialResultFinancialServiceService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public FinancialResultFinancialServiceService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<GetFinancialResultFinancialServiceDTO> GetAll(int skip, int take)
    {
        return _mapper.Map<ICollection<GetFinancialResultFinancialServiceDTO>>(
            _context.FinancialResultsFinancialServices?
                .Skip(skip)
                .Take(take)
                .ToList()
        );
    }

    public GetFinancialResultFinancialServiceDTO? Get(int id)
    {
        return _mapper.Map<GetFinancialResultFinancialServiceDTO>(
            _context.FinancialResultsFinancialServices?.FirstOrDefault(
                frfs => frfs.ID == id
            )
        );
    }

    public GetFinancialResultFinancialServiceDTO? Post(PostFinancialResultFinancialServiceDTO frfsDTO)
    {
        GetFinancialResultFinancialServiceDTO? result = null;
        FinancialResultFinancialService frfs = _mapper.Map<FinancialResultFinancialService>(frfsDTO);

        if (!CheckExistingFinancialResultFinancialServiceByID(frfs))
        {
            frfs = UpdateForeignReferences(frfs);
            _context.FinancialResultsFinancialServices?.Add(frfs);
            _context.SaveChanges();
            result = _mapper.Map<GetFinancialResultFinancialServiceDTO>(frfs);
        }

        return result;
    }

    public bool Put(PutFinancialResultFinancialServiceDTO frfsDTO)
    {
        bool result = false;

        FinancialResultFinancialService? frfs = _context.FinancialResultsFinancialServices?.FirstOrDefault(
            fr => fr.ID == frfsDTO.ID
        );

        if (frfs != null)
        {
            _mapper.Map(frfsDTO, frfs);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    public bool Delete(int ID)
    {
        bool result = false;
        
        FinancialResultFinancialService? frfs = _context.FinancialResultsFinancialServices?.FirstOrDefault(
            frfs => frfs.ID == ID
        );

        if (frfs != null)
        {
            _context.Remove(frfs);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    private bool CheckExistingFinancialResultFinancialServiceByID(FinancialResultFinancialService frfs)
    {
        bool result = false;

        if (_context.FinancialResultsFinancialServices != null)
        {
            var financialResultFinancialServices = _context.FinancialResultsFinancialServices.ToList();
            foreach (var fResultFService in financialResultFinancialServices)
            {
                if (!result)
                {
                    result = (fResultFService.ID == frfs.ID);
                }
            }
            System.Console.WriteLine(result);
        }

        return result;
    }

    private FinancialResultFinancialService UpdateForeignReferences(FinancialResultFinancialService frfs)
    {
        FinancialResult? financialResult = _context.FinancialResults?.FirstOrDefault(
            fr => fr.ID == frfs.FinancialResultID
        );

        FinancialService? financialService = _context.FinancialServices?.FirstOrDefault(
            fs => fs.Id == frfs.FinancialServiceID
        );

        frfs.FinancialResult = financialResult;
        frfs.FinancialService = financialService;

        return frfs;
    }
}