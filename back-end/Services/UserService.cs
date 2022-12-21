using AutoMapper;
using Efficiency.Data.DTO.User;
using Efficiency.Models;
using Microsoft.AspNetCore.Identity;

namespace Efficiency.Services;

public class UserService
{
    private UserManager<User> _manager;
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public UserService(AppDbContext context, IMapper mapper, UserManager<User> manager)
    {
        _context = context;
        _mapper = mapper;
        _manager = manager;
    }

    public ICollection<GetUserDTO>? GetAll()
    {
        ICollection<User>? users = _manager.Users.ToList();
        return _mapper.Map<ICollection<GetUserDTO>>(users);
    }

    public GetUserDTO? Get(int id)
    {
        return _mapper.Map<GetUserDTO>(
            _context.Users.FirstOrDefault(user => user.Id == id)
        );
    }

    public GetUserDTO? Post(PostUserDTO userDTO)
    {
        GetUserDTO? result = null;

        User user = ReturnReadyUser(userDTO);

        var creation = _manager.CreateAsync(user, userDTO.Password);

        if (creation.Result.Succeeded)
        {
            result = _mapper.Map<GetUserDTO>(user);
        }
        
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

        // sets user's username to be his first and last names in lower case and without spaces
        user.UserName = 
            user.FirstName?.ToLower()
            + user.LastName?.ToLower().Replace(" ", "");

        return user;
    }
}