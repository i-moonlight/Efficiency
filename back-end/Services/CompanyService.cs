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
        Company company = _mapper.Map<Company>(companyDTO);

        _context.Companies?.Add(company);
        _context.SaveChanges();

        GetCompanyDTO result = _mapper.Map<GetCompanyDTO>(company);

        return result;
    }
}