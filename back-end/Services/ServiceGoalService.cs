using AutoMapper;

namespace Efficiency.Services;

public class ServiceGoalService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public ServiceGoalService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // TODO
    // public void GetAll(){}
    // public void Get(int ID){}
    // public void Post(PostServiceResultDTO serviceResultDTO){}
    // public void Put(PutServiceResultDTO serviceResultDTO){}
    // public void Delete(int ID){}
}