using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Efficiency.Models;

public class Employee
{
    [Key]
    public int RegistrationNumber { get; set; }

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