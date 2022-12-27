using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Efficiency.Models;

public class FinancialResult
{
    [Key]
    public int ID { get; set; }

    public DateTime Date { get; set; }

    public decimal ProductSalesResult { get; set; }

    [JsonIgnore]
    public virtual ICollection<Employee>? Employees { get; set; }

    [JsonIgnore]
    public virtual ICollection<EmployeeFinancialResult>? EmployeesFinancialResults { get; set; }

    [JsonIgnore]
    public virtual ICollection<FinancialService>? FinancialServices { get; set; }
    
    [JsonIgnore]
    public virtual ICollection<FinancialResultFinancialService>? FinancialResultsFinancialServices { get; set; }
}