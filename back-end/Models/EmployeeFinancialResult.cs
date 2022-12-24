using System.Text.Json.Serialization;

namespace Efficiency.Models;

public class EmployeeFinancialResult
{
    [JsonIgnore]
    public int EmployeeID { get; set; }
    [JsonIgnore]
    public virtual Employee? Employee { get; set; }
    [JsonIgnore]
    public int FinancialResultID { get; set; }
    [JsonIgnore]
    public virtual FinancialResult? FinancialResult { get; set; }
}