using System;
using AutoMapper;
using Efficiency.Data;
using Efficiency.Data.DTO;
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

    public ICollection<GetUserDTO>? GetAll()
    {
        return _mapper.Map<ICollection<GetUserDTO>>(_context.Users.ToList());
    }

    public GetUserDTO? Get(int id)
    {
        return _mapper.Map<GetUserDTO>(
            _context.Users.FirstOrDefault(user => user.Id.Equals(id))
        );
    }
}