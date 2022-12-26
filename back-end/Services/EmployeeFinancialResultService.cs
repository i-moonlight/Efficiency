using AutoMapper;
using Efficiency.Data.DTO.EmployeeFinancialResult;
using Efficiency.Models;

namespace Efficiency.Services;

public class EmployeeFinancialResultService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public EmployeeFinancialResultService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<GetEmployeeFinancialResultDTO> GetAll(int skip, int take)
    {
        return _mapper.Map<ICollection<GetEmployeeFinancialResultDTO>>(
            _context.EmployeesFinancialResults?
                .Skip(skip)
                .Take(take)
                .ToList()
        );
    }

    public GetEmployeeFinancialResultDTO? Get(int id)
    {
        return _mapper.Map<GetEmployeeFinancialResultDTO>(
            _context.EmployeesFinancialResults?.FirstOrDefault(
                efr => efr.ID == id
            )
        );
    }

    public GetEmployeeFinancialResultDTO? Post(PostEmployeeFinancialResultDTO employeeFinancialResultDTO)
    {
        GetEmployeeFinancialResultDTO? result = null;
        EmployeeFinancialResult employeeFinancialResult = _mapper.Map<EmployeeFinancialResult>(employeeFinancialResultDTO);

        if (!CheckExistingEmployeeFinancialResultByForeignIDs(employeeFinancialResult))
        {
            employeeFinancialResult = UpdateForeignReferences(employeeFinancialResult);
            
            _context.EmployeesFinancialResults?.Add(employeeFinancialResult);
            _context.SaveChanges();
            result = _mapper.Map<GetEmployeeFinancialResultDTO>(employeeFinancialResult);
        }

        return result;
    }

    public bool Put(PutEmployeeFinancialResultDTO employeeFinancialResultDTO)
    {
        bool result = false;

        EmployeeFinancialResult? employeeFinancialResult = _context.EmployeesFinancialResults?.FirstOrDefault(
            e => e.ID == employeeFinancialResultDTO.ID
        );

        if (employeeFinancialResult != null)
        {
            _mapper.Map(employeeFinancialResultDTO, employeeFinancialResult);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    public bool Delete(int id)
    {
        bool result = false;
        
        EmployeeFinancialResult? EmployeeFinancialResult = _context.EmployeesFinancialResults?.FirstOrDefault(
            efr => efr.ID == id
        );

        if (EmployeeFinancialResult != null)
        {
            _context.Remove(EmployeeFinancialResult);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    private bool CheckExistingEmployeeFinancialResultByForeignIDs(EmployeeFinancialResult employeeFinancialResult)
    {
        bool result = false;

        if (_context.EmployeesFinancialResults != null)
        {
            var employeeFinancialResults = _context.EmployeesFinancialResults.ToList();
            foreach (var efr in employeeFinancialResults)
            {
                if (!result)
                {
                    result = (efr.EmployeeID == employeeFinancialResult.EmployeeID 
                        && efr.FinancialResultID == employeeFinancialResult.FinancialResultID);
                }
            }
            System.Console.WriteLine(result);
        }

        return result;
    }

    private EmployeeFinancialResult UpdateForeignReferences(EmployeeFinancialResult employeeFinancialResult)
    {
        employeeFinancialResult.Employee = _context.Employees?.FirstOrDefault(
            e => e.RegistrationNumber == employeeFinancialResult.EmployeeID
        );

        employeeFinancialResult.FinancialResult = _context.FinancialResults?.FirstOrDefault(
            fr => fr.ID == employeeFinancialResult.ID
        );

        return employeeFinancialResult;
    }
}