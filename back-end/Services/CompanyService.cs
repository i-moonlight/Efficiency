using AutoMapper;
using Efficiency.Data.DTO.Company;
using Efficiency.Models;

namespace Efficiency.Services;

public class CompanyService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public CompanyService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<GetCompanyDTO> GetAll(int skip, int take)
    {
        return _mapper.Map<ICollection<GetCompanyDTO>>(
            _context.Companies?
                .Skip(skip)
                .Take(take)
                .ToList()
        );
    }

    public GetCompanyDTO? GetAll(int id)
    {
        return _mapper.Map<GetCompanyDTO>(
            _context.Companies?.FirstOrDefault(
                c => c.ID == id
            )
        );
    }

    public GetCompanyDTO? Post(PostCompanyDTO companyDTO)
    {
        GetCompanyDTO? result = null;
        Company company = _mapper.Map<Company>(companyDTO);

        if (!CheckExistingCompanyByName(company))
        {
            _context.Companies?.Add(company);
            _context.SaveChanges();
            result = _mapper.Map<GetCompanyDTO>(company);
        }

        return result;
    }

    public bool Put(PutCompanyDTO companyDTO)
    {
        bool result = false;

        Company? company = _context.Companies?.FirstOrDefault(
            c => c.ID == companyDTO.ID
        );

        if (company != null)
        {
            _mapper.Map(companyDTO, company);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    public bool Delete(int id)
    {
        bool result = false;
        
        Company? company = _context.Companies?.FirstOrDefault(
            c => c.ID == id
        );

        if (company != null)
        {
            // var users = company.Users?.ToList();
            // foreach (var user in users)
            // {
            //     user.Company = null;
            //     user.CompanyID = null;
            // }
            _context.Remove(company);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    private bool CheckExistingCompanyByName(Company company)
    {
        bool result = false;

        if (_context.Companies != null)
        {
            var companies = _context.Companies.ToList();
            foreach (var c in companies)
            {
                if (c.Name != null && company.Name != null)
                {
                    result = (c.Name.ToUpper().Equals(company.Name.ToUpper()));
                }
            }
            System.Console.WriteLine(result);
        }

        return result;
    }
}