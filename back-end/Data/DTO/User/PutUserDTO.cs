using System.ComponentModel.DataAnnotations;
using Efficiency.Models;

namespace Efficiency.Data.DTO.User;

public class PutUserDTO
{
    [Required(ErrorMessage = "User ID is required")]
    public int ID { get; set; }
    [Required(ErrorMessage = "User password is required")]
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string? Phone { get; set; }
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    public string? Role { get; set; }
    public Subscription SubscriptionType { get; set; }
    public int? StoreID { get; set; }
}