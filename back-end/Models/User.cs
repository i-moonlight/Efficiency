using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Efficiency.Models;

public class User : IdentityUser<int>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Role { get; set; }
    public bool? PaymentOnDay { get; set; }
    public bool? FirstLogin { get; set; }

    [JsonIgnore]
    public virtual Store? Store { get; set; }
    public int? StoreID { get; set; }
}