using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Efficiency.Models;

public class Store
{
    [Key]
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? Street { get; set; }
    public string? District { get; set; }
    public string? Complement { get; set; }
    public string? Observations { get; set; }
    public string? ZipCode { get; set; }

    [JsonIgnore]
    public virtual ICollection<User>? Users { get; set; }
    [JsonIgnore]
    public virtual ICollection<Seller>? Sellers { get; set; }
    [JsonIgnore]
    public virtual ICollection<Goal>? Goals { get; set; }
    [JsonIgnore]
    public virtual ICollection<Service>? Services { get; set; }
}