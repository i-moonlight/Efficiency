using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.User;

public class PostUserDTO
{
    [Required(ErrorMessage="User's first name is required")]
    public string? FirstName { get; set; }
    
    [Required(ErrorMessage="User's last name is required")]
    public string? LastName { get; set; }

    [Required(ErrorMessage="User's phone number is required")]
    public string? Phone { get; set; }
    
    [Required(ErrorMessage="User's e-mail is required")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage="User's role is required")]
    public string? Role { get; set; }
    
    public int? CompanyID { get; set; }
}