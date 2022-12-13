using System.ComponentModel.DataAnnotations;

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
    public Company? CompanyReference { get; set; }
    public int? CompanyID { get; set; }
    public ICollection<FinancialResult>? FinancialResults { get; set; }
    
}