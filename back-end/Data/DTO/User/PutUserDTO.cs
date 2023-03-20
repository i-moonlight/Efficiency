using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.User;

public class PutUserDTO
{
    [Required(ErrorMessage = "User ID is required")]
    public int ID { get; set; }

    [Required(ErrorMessage = "User password is required")]
    public string? Password { get; set; }

    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }
    
    public string? Email { get; set; }
    
    public string? Role { get; set; }
    
    public int? StoreID { get; set; }
}