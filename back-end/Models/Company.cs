using System.ComponentModel.DataAnnotations;

namespace Efficiency.Models;

public class Company
{
    [Key]
    [Required(ErrorMessage = "The company's primary key is not optional")]
    public int ID { get; set; }
    [Required(ErrorMessage = "The company's name is not optional")]
    public string Name { get; set; }
    public ICollection<User>? Users { get; set; }
    public ICollection<Employee>? Employees { get; set; }
}