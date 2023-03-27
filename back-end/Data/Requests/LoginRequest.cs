using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.Requests;

public class LoginRequest
{
    [Required(ErrorMessage = "The user's e-mail is mandatory to login")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "The password is mandatory to login")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}