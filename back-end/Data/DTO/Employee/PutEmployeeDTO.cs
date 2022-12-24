using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.Employee;

public class PutEmployeeDTO
{
    [Required(ErrorMessage = "Employee's registration number is not optional")]
    public int RegistrationNumber { get; set; }
    [Required(ErrorMessage = "Employee's name number is not optional")]
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    [Required(ErrorMessage = "Employee's company reference is not optional")]
    public int? CompanyID { get; set; }
}