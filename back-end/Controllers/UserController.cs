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
        [FromQuery] int skip=0,
        [FromQuery] int take=50)
    {
        IActionResult result = NotFound();

        ICollection<GetUserDTO>? users = _service.GetAll(skip, take);

        if (users != null)
        {
            result = Ok(users);
        }

        return result;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        IActionResult result = NotFound();

        GetUserDTO? user = _service.Get(id);
        
        if (user != null)
        {
            result = Ok(user);
        }

        return result;
    }

    [HttpPost("/signup")]
    public IActionResult SignUp([FromBody] PostUserDTO userDTO)
    {
        IActionResult result = StatusCode(500);

        GetUserDTO? createdUser = _service.SignUp(userDTO);

        if (createdUser != null)
        {
            result = CreatedAtAction(nameof(Get), new { id = createdUser.Id }, createdUser);
        }

        return result;
    }

    [HttpPost("/login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        System.Console.WriteLine(request.ToString());
        IActionResult result = Unauthorized("User credentials are incorrect or account not confirmed.");

        Token? createdUserToken = _service.Login(request);

        if (createdUserToken != null)
        {
            result = Ok(createdUserToken);
        }

        return result;
    }

    [HttpPut]
    public IActionResult Put([FromBody] PutUserDTO userDTO)
    {
        IActionResult result = NotFound("User does not exist or password is incorrect");

        bool updateSuccess = _service.Put(userDTO);

        if (updateSuccess)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        IActionResult result = NotFound();

        bool deleteSuccess = _service.Delete(id);

        if (deleteSuccess)
        {
            result = NoContent();
        }

        return result;
    }
}