using Efficiency.Models;

namespace Efficiency.Data.DTO.FinancialResult;

public class GetFinancialResultDTO
{
    public int ID { get; set; }
    public DateTime Date { get; set; }
    public decimal ProductSalesResult { get; set; }
    public virtual ICollection<Models.Employee>? Employees { get; set; }
    public virtual ICollection<Models.EmployeeFinancialResult>? EmployeesFinancialResults { get; set; }
    public virtual ICollection<Models.FinancialService>? FinancialServices { get; set; }
    public virtual ICollection<Models.FinancialResultFinancialService>? FinancialResultsFinancialServices { get; set; }
}