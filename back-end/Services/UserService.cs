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

        User user = ReturnReadyUser(_mapper.Map<User>(userDTO));

        if (!CheckExistingUserByEmail(user) || !CheckExistingUserByPhoneNumber(user))
        {
            var creation = _manager.CreateAsync(user, userDTO.Password);

            if (creation.Result.Succeeded)
            {
                result = _mapper.Map<GetUserDTO>(user);
            }
        }

        return result;
    }

    public bool Put(PutUserDTO userDTO)
    {
        bool result = false;

        User? user = _manager.Users.FirstOrDefault(u => u.Id == userDTO.Id);
        
        if (user != null)
        {
            System.Console.WriteLine("user was found");

            var checkPassword = _manager.CheckPasswordAsync(user, userDTO.Password);

            if (checkPassword.Result)
            {
                System.Console.WriteLine("user password is correct");

                _mapper.Map(userDTO, user);

                var updateUser = _manager.UpdateAsync(user);

                if (updateUser.Result.Succeeded)
                {
                    System.Console.WriteLine("user info was updated successfully");
                    result = true;
                }
            }
        }

        return result;
    }

    public bool Delete(int id)
    {
        bool result = false;

        User? user = _manager.Users.FirstOrDefault(
            u => u.Id == id
        );

        if (user != null)
        {
            var deleteResult = _manager.DeleteAsync(user);
            result = deleteResult.Result.Succeeded;
        }

        return result;
    }

    private bool CheckExistingUserByEmail(User user)
    {
        var result = _manager.Users.FirstOrDefault(
            u => u.NormalizedEmail.Equals(user.Email.ToUpper())
        );

        return result != null;
    }

    private bool CheckExistingUserByPhoneNumber(User user)
    {
        User? result = _manager.Users.FirstOrDefault(
            u => u.PhoneNumber.Equals(user.PhoneNumber)
        );

        return result != null;
    }

    private User ReturnReadyUser(User user)
    {
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

    private User UpdateUserInformation(PutUserDTO userDTO, User user)
    {
        User newUser = _mapper.Map<User>(userDTO);
        newUser = ReturnReadyUser(newUser);

        newUser.AccessFailedCount = user.AccessFailedCount;
        newUser.ConcurrencyStamp = user.ConcurrencyStamp;
        newUser.EmailConfirmed = user.EmailConfirmed;
        newUser.LockoutEnabled = user.LockoutEnabled;
        newUser.LockoutEnd = user.LockoutEnd;
        newUser.NormalizedEmail = userDTO.Email?.ToUpper();
        newUser.NormalizedUserName = userDTO.UserName?.ToUpper();
        newUser.PasswordHash = user.PasswordHash;
        newUser.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
        newUser.SecurityStamp = user.SecurityStamp;
        newUser.TwoFactorEnabled = user.TwoFactorEnabled;

        return newUser;
    }
}