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
        return _mapper.Map<ICollection<GetUserDTO>>(_context.Users.ToList());
    }

    public GetUserDTO? Get(int id)
    {
        return _mapper.Map<GetUserDTO>(
            _context.Users.FirstOrDefault(user => user.Id.Equals(id))
        );
    }

    public GetUserDTO? Post(PostUserDTO userDTO)
    {
        GetUserDTO? result = null;

        User user = ReturnReadyUser(userDTO);

        var creation = _manager.CreateAsync(user);
        var roleCreation = _manager.AddToRoleAsync(user, "user");

        if (creation.Result.Succeeded && roleCreation.Result.Succeeded)
        {
            result = _mapper.Map<GetUserDTO>(user);
        }
        
        //
        
        return result;
    }

    private User ReturnReadyUser(PostUserDTO userDTO)
    {
        User user = _mapper.Map<User>(userDTO);
        // sets the username to be it's full name without spaces
        user.UserName = user.FirstName.Trim() + user.LastName.Replace(" ", "");

        // sets all the 'normalized' fields to be equal to it's 'non normalized' variants in upper case
        user.NormalizedEmail = user.Email.ToUpper();
        user.NormalizedUserName = user.UserName.ToUpper();



        return user;
    }
}