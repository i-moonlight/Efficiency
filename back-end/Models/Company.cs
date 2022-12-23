using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Efficiency.Models;

public class Company
{
    [Key]
    [Required(ErrorMessage = "The company's primary key is not optional")]
    public int ID { get; set; }
    [Required(ErrorMessage = "The company's name is not optional")]
    public string? Name { get; set; }
    [JsonIgnore]
    public virtual ICollection<User>? Users { get; set; }
    [JsonIgnore]
    public virtual ICollection<Employee>? Employees { get; set; }
}