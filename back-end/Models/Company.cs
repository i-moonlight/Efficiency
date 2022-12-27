using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Efficiency.Models;

public class Company
{
    [Key]
    public int ID { get; set; }

    public string? Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<User>? Users { get; set; }
    
    [JsonIgnore]
    public virtual ICollection<Employee>? Employees { get; set; }
}