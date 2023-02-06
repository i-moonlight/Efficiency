using AutoMapper;
using Efficiency.Data.DTO.User;
using Efficiency.Data.Requests;
using Efficiency.Models;
using Microsoft.AspNetCore.Identity;

namespace Efficiency.Services;

public class UserService
{
    private TokenService _tokenService;
    private SignInManager<User> _signInManager;
    private UserManager<User> _userManager;
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public UserService(AppDbContext context, IMapper mapper, UserManager<User> manager, SignInManager<User> signInManager, TokenService tokenService)
    {
        _context = context;
        _mapper = mapper;
        _userManager = manager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public ICollection<GetUserDTO>? GetAll(int skip, int take)
    {
        ICollection<User>? users = _userManager.Users
            .Skip(skip)
            .Take(take)
            .ToList();
        return _mapper.Map<ICollection<GetUserDTO>>(users);
    }

    public GetUserDTO? Get(int id)
    {
        return _mapper.Map<GetUserDTO>(
            _context.Users.FirstOrDefault(user => user.Id == id)
        );
    }

    public GetUserDTO? SignUp(PostUserDTO userDTO)
    {
        GetUserDTO? result = null;

        User user = ReturnReadyUser(_mapper.Map<User>(userDTO));

        if (!CheckExistingUserByEmail(user) || !CheckExistingUserByPhoneNumber(user))
        {
            var creation = _userManager.CreateAsync(user, userDTO.Password);

            if (creation.Result.Succeeded)
            {
                result = _mapper.Map<GetUserDTO>(user);
            }
        }

        return result;
    }

    public Token? Login(LoginRequest request)
    {
        Token? result = null;

        User? user = _userManager.Users.FirstOrDefault((user) => 
                request.Email != null && user.NormalizedEmail.Equals(request.Email.ToUpper()));
        if(user != null){
            System.Console.WriteLine("User found");
            var signInResult = _signInManager.PasswordSignInAsync(user, request.Password, false, false);

            if (signInResult.Result.Succeeded){
                System.Console.WriteLine("Correct user credentials provided");
                result = _tokenService.Generate(user);
            } else {
                System.Console.WriteLine("Incorrect user credentials provided");
            }
        } else {
            System.Console.WriteLine("User e-mail not registered");
        }

        return result;
    }

    public bool Put(PutUserDTO userDTO)
    {
        bool result = false;

        User? user = _userManager.Users.FirstOrDefault(u => u.Id == userDTO.Id);
        
        if (user != null)
        {
            System.Console.WriteLine("user was found");

            var checkPassword = _userManager.CheckPasswordAsync(user, userDTO.Password);

            if (checkPassword.Result)
            {
                System.Console.WriteLine("user password is correct");

                _mapper.Map(userDTO, user);
                user = ReturnReadyUser(user);

                var updateUser = _userManager.UpdateAsync(user);

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

        User? user = _userManager.Users.FirstOrDefault(
            u => u.Id == id
        );

        if (user != null)
        {
            var deleteResult = _userManager.DeleteAsync(user);
            result = deleteResult.Result.Succeeded;
        }

        return result;
    }

    private bool CheckExistingUserByEmail(User user)
    {
        var result = _userManager.Users.FirstOrDefault(
            u => u.NormalizedEmail.Equals(user.Email.ToUpper())
        );

        return result != null;
    }

    private bool CheckExistingUserByPhoneNumber(User user)
    {
        User? result = _userManager.Users.FirstOrDefault(
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

}