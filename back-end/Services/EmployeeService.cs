using AutoMapper;
using Efficiency.Data.DTO.Employee;
using Efficiency.Models;

namespace Efficiency.Services;

public class EmployeeService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public EmployeeService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<GetEmployeeDTO> GetAll(int skip, int take)
    {
        return _mapper.Map<ICollection<GetEmployeeDTO>>(
            _context.Employees?
                .Skip(skip)
                .Take(take)
                .ToList()
        );
    }

    public GetEmployeeDTO? GetAll(int registrationNumber)
    {
        return _mapper.Map<GetEmployeeDTO>(
            _context.Employees?.FirstOrDefault(
                e => e.RegistrationNumber == registrationNumber
            )
        );
    }

    public GetEmployeeDTO? Post(PostEmployeeDTO employeeDTO)
    {
        GetEmployeeDTO? result = null;
        Employee employee = _mapper.Map<Employee>(employeeDTO);

        if (!CheckExistingEmployeeByName(employee))
        {
            _context.Employees?.Add(employee);
            _context.SaveChanges();
            result = _mapper.Map<GetEmployeeDTO>(employee);
        }

        return result;
    }

    public bool Put(PutEmployeeDTO employeeDTO)
    {
        bool result = false;

        Employee? Employee = _context.Employees?.FirstOrDefault(
            e => e.RegistrationNumber == employeeDTO.RegistrationNumber
        );

        if (Employee != null)
        {
            _mapper.Map(employeeDTO, Employee);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    public bool Delete(int registrationNumber)
    {
        bool result = false;
        
        Employee? Employee = _context.Employees?.FirstOrDefault(
            e => e.RegistrationNumber == registrationNumber
        );

        if (Employee != null)
        {
            _context.Remove(Employee);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    private bool CheckExistingEmployeeByName(Employee Employee)
    {
        bool result = false;

        if (_context.Employees != null)
        {
            var Employees = _context.Employees.ToList();
            foreach (var c in Employees)
            {
                if (c.Name != null && Employee.Name != null)
                {
                    result = (c.Name.ToUpper().Equals(Employee.Name.ToUpper()));
                }
            }
            System.Console.WriteLine(result);
        }

        return result;
    }
}