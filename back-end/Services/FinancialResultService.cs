using AutoMapper;
using Efficiency.Data.DTO.FinancialResult;
using Efficiency.Models;

namespace Efficiency.Services;

public class FinancialResultService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public FinancialResultService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<GetFinancialResultDTO> GetAll(int skip, int take)
    {
        return _mapper.Map<ICollection<GetFinancialResultDTO>>(
            _context.FinancialResults?
                .Skip(skip)
                .Take(take)
                .ToList()
        );
    }

    public GetFinancialResultDTO? GetAll(int id)
    {
        return _mapper.Map<GetFinancialResultDTO>(
            _context.FinancialResults?.FirstOrDefault(
                fr => fr.ID == id
            )
        );
    }

    public GetFinancialResultDTO? Post(PostFinancialResultDTO financialResultDTO)
    {
        GetFinancialResultDTO? result = null;
        FinancialResult financialResult = _mapper.Map<FinancialResult>(financialResultDTO);

        if (!CheckExistingFinancialResultByName(financialResult))
        {
            _context.FinancialResults?.Add(financialResult);
            _context.SaveChanges();
            result = _mapper.Map<GetFinancialResultDTO>(financialResult);
        }

        return result;
    }

    public bool Put(PutFinancialResultDTO financialResultDTO)
    {
        bool result = false;

        FinancialResult? financialResult = _context.FinancialResults?.FirstOrDefault(
            fr => fr.ID == financialResultDTO.ID
        );

        if (financialResult != null)
        {
            _mapper.Map(financialResultDTO, financialResult);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    public bool Delete(int ID)
    {
        bool result = false;
        
        FinancialResult? financialResult = _context.FinancialResults?.FirstOrDefault(
            fr => fr.ID == ID
        );

        if (financialResult != null)
        {
            _context.Remove(financialResult);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    private bool CheckExistingFinancialResultByName(FinancialResult financialResult)
    {
        bool result = false;

        if (_context.FinancialResults != null)
        {
            var FinancialResults = _context.FinancialResults.ToList();
            foreach (var fResult in FinancialResults)
            {
                result = (fResult.ID == financialResult.ID) || result;
            }
            System.Console.WriteLine(result);
        }

        return result;
    }
}