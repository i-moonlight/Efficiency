using System.ComponentModel.DataAnnotations;
using Efficiency.Models;

namespace Efficiency.Data.DTO.User;

public class PostUserDTO
{
    [Required(ErrorMessage = "User's password is required")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    [Required(ErrorMessage = "User's first name is required")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "User's last name is required")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "User's phone number is required")]
    [DataType(DataType.PhoneNumber)]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "User's e-mail is required")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Required(ErrorMessage = "User's role is required")]
    public string? Role { get; set; }

    [Required(ErrorMessage = "Subscription type is required")]
    public Subscription SubscriptionType { get; set; }
}