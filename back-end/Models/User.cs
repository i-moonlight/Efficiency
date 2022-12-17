using Microsoft.AspNetCore.Identity;

namespace Efficiency.Models;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Role { get; set; }
    public virtual Company? Company { get; set; }
    public int? CompanyID { get; set; }

}