using AutoMapper;
using Efficiency.Data.DTO.Company;

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

    public ICollection<GetCompanyDTO> GetAll()
    {
        return _mapper.Map<ICollection<GetCompanyDTO>>(
            _context.Companies?.ToList()
        );
    }
}