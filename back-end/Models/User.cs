using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Efficiency.Models;

public class User : IdentityUser<int>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Role { get; set; }
    public Subscription SubscriptionType { get; set; }
    public DateTime? SubscriptionBegin { get; set; }
    public DateTime? SubscriptionExpiration { get; set; }
    public bool? FirstLogin { get; set; } = true;
    public int? StoreID { get; set; }

    [JsonIgnore]
    public virtual Store? Store { get; set; }
}