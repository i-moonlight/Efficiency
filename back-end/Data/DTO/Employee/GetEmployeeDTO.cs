using Efficiency.Models;

namespace Efficiency.Data.DTO.Employee;

public class GetEmployeeDTO
{
    public int RegistrationNumber { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public virtual Models.Company? CompanyReference { get; set; }
    public virtual ICollection<Models.FinancialResult>? FinancialResults { get; set; }
}