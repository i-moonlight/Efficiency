using Efficiency.Models;

namespace Efficiency.Data.DTO.EmployeeFinancialResult;

public class GetEmployeeFinancialResultDTO
{
    public int ID { get; set; }
    public virtual Models.Employee? Employee { get; set; }
    public virtual Models.FinancialResult? FinancialResult { get; set; }
}