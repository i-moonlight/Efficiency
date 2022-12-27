using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Efficiency.Models;

public class User : IdentityUser<int>
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Role { get; set; }

    [JsonIgnore]
    public virtual Company? Company { get; set; }
    
    [JsonIgnore]
    public int? CompanyID { get; set; }
}