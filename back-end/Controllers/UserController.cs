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
    public IActionResult GetAll()
    {
        IActionResult result = NotFound();

        ICollection<User>? users = _service.GetAll();

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

        User? user = _service.Get(id);
        
        if (user != null)
        {
            result = Ok(user);
        }

        return result;
    }
}