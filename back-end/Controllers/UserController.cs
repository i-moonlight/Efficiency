using Efficiency.Data.DTO.Store;
using Efficiency.Data.DTO.User;
using Efficiency.Data.Requests;
using Efficiency.Models;
using Efficiency.Services;
using Microsoft.AspNetCore.Mvc;

namespace Efficiency.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 500)
    {
        IActionResult result = NotFound();

        ICollection<GetUserDTO>? users = _service.GetAll(skip, take);

        if (users != null)
        {
            result = Ok(users);
        }

        return result;
    }

    [HttpGet("{userID}")]
    public IActionResult GetUser(int userID)
    {
        IActionResult result = NotFound();

        GetUserDTO? user = _service.Get(userID);

        if (user != null)
        {
            result = Ok(user);
        }

        return result;
    }

    [HttpPost("/signup")]
    public IActionResult SignUp([FromBody] PostUserDTO userDTO)
    {
        IActionResult result = Unauthorized("The provided e-mail is already registered");

        GetUserDTO? createdUser = _service.SignUp(userDTO);

        if (createdUser != null)
        {
            result = CreatedAtAction(
                nameof(GetUser),
                new { userID = createdUser.ID },
                createdUser
            );
        }

        return result;
    }

    [HttpPost("/login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        IActionResult result = Unauthorized("User credentials are incorrect or account not confirmed.");

        Token? loggedUserToken = _service.Login(request);

        if (loggedUserToken != null)
        {
            result = Ok(loggedUserToken);
        }

        return result;
    }

    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        IActionResult result = Unauthorized();

        bool logoutResult = _service.Logout();

        if (logoutResult)
        {
            result = Ok("User logged out successfully");
        }

        return result;
    }

    [HttpPut]
    public IActionResult UpdateUser([FromBody] PutUserDTO userDTO)
    {
        IActionResult result = NotFound("User wasn't found or credentials are incorrect");

        bool updateSuccess = _service.Put(userDTO);

        if (updateSuccess)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{userID}")]
    public IActionResult DeleteUser(int userID)
    {
        IActionResult result = NotFound();

        bool deleteSuccess = _service.Delete(userID);

        if (deleteSuccess)
        {
            result = NoContent();
        }

        return result;
    }
}