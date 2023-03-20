using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Efficiency.Models;

public class Service
{
    [Key]
    public int ID { get; set; }    
    public string? Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<Result>? Results { get; set; }

    [JsonIgnore]
    public virtual ICollection<Goal>? Goals { get; set; }
}