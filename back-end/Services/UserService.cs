using AutoMapper;
using Efficiency.Data.DTO.User;
using Efficiency.Models;
using Microsoft.AspNetCore.Identity;

namespace Efficiency.Services;

public class UserService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public UserService(
        AppDbContext context, 
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<GetUserDTO>? GetAll()
    {
        ICollection<User>? users = _context.Users?.ToList();
        return _mapper.Map<ICollection<GetUserDTO>>(users);
    }

    public GetUserDTO? Get(int id)
    {
        return _mapper.Map<GetUserDTO>(
            _context.Users?.FirstOrDefault(user => user.Id == id)
        );
    }

    public GetUserDTO? Post(PostUserDTO userDTO)
    {

        User user = ReturnReadyUser(userDTO);

        _context.Users?.AddAsync(user);
        _context.SaveChanges();

        GetUserDTO? result = _mapper.Map<GetUserDTO>(user);
        
        return result;
    }

    private User ReturnReadyUser(PostUserDTO userDTO)
    {
        User user = _mapper.Map<User>(userDTO);

        // remove possible initial and end spaces in user's first and last names
        user.FirstName = user.FirstName?.Trim();
        user.LastName = user.LastName?.Trim();

        // sets user's e-mail to have only lower case characters
        user.Email = user.Email?.ToLower();

        return user;
    }
}