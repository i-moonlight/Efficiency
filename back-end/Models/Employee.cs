using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Efficiency.Models;

public class Employee
{
    [Key]
    [Required(ErrorMessage = "The employee's Registration Number is not optional")]
    public int RegistrationNumber { get; set; }

    [Required(ErrorMessage = "The employee's name is not optional")]
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    [JsonIgnore]
    public virtual Company? CompanyReference { get; set; }
    [JsonIgnore]
    public int? CompanyID { get; set; }
    [JsonIgnore]
    public virtual ICollection<FinancialResult>? FinancialResults { get; set; }
    [JsonIgnore]
    public virtual ICollection<EmployeeFinancialResult>? EmployeesFinancialResults { get; set; }
    
}