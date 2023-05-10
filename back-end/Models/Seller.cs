using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Efficiency.Models;

public class Seller
{
    [Key]
    public int ID { get; set; }
    public int RegistrationNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public bool Active { get; set; }

    [JsonIgnore]
    public int? StoreID { get; set; }
    [JsonIgnore]
    public virtual Store? Store { get; set; }
    [JsonIgnore]
    public virtual ICollection<Result>? Results { get; set; }
}