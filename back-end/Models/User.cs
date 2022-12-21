using Microsoft.AspNetCore.Identity;

namespace Efficiency.Models;

public class User
{
    public int? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
    public string? Email { get; set; }
    public bool? EmailConfirmed { get; set; }
    public string? PhoneNumber { get; set; }
    public bool? PhoneNumberConfirmed { get; set; }
    public bool? TwoFactorEnabled { get; set; }
    public virtual Company? Company { get; set; }
    public int? CompanyID { get; set; }
}