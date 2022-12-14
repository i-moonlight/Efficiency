using System.ComponentModel.DataAnnotations;

namespace Efficiency.Models;

public class User
{
    [Key]
    [Required(ErrorMessage = "The user's primary key is not optional")]
    public int UserID { get; set; }

    [Required(ErrorMessage = "The user's name is not optional")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The user's phone number is not optional")]
    public string Phone { get; set; }
    
    [Required(ErrorMessage = "The user's e-mail is not optional")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "The user's role is not optional")]
    public string Role { get; set; }
    
    public virtual Company? Company { get; set; }
    public int CompanyID { get; set; }

}