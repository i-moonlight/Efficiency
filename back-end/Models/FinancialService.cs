using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Efficiency.Models;

public class FinancialService
{
    [Key]
    public int Id { get; set; }
    
    public string? Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<FinancialResult>? FinancialResults { get; set; }
    
    [JsonIgnore]
    public virtual ICollection<FinancialResultFinancialService>? FinancialResultsFinancialServices { get; set; }
}