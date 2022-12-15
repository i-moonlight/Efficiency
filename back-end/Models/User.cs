using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Efficiency.Models;

public class User : IdentityUser
{
    [Key]
    [Required(ErrorMessage = "The user's primary key is not optional")]
    public int UserID { get; set; }

    [Required(ErrorMessage = "The user's name is not optional")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The user's phone number is not optional")]
    public string? Phone { get; set; }
    
    [Required(ErrorMessage = "The user's e-mail is not optional")]
    public override string? Email { get; set; }
    
    [Required(ErrorMessage = "The user's role is not optional")]
    public string? Role { get; set; }
    
    public virtual Company? Company { get; set; }
    public int CompanyID { get; set; }

}