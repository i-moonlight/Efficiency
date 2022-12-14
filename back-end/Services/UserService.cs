using AutoMapper;
using Efficiency.Models;

namespace Efficiency.Services;

public class UserService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public UserService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<User>? GetAll()
    {
        throw new NotImplementedException();
    }

    public User? Get(int id)
    {
        throw new NotImplementedException();
    }
}