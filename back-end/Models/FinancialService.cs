using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Efficiency.Models;

public class FinancialService
{
    [Key]
    [Required(ErrorMessage = "The financial service's id is not optional")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "The financial service's name is not optional")]
    public string? Name { get; set; }
    [JsonIgnore]
    public virtual ICollection<FinancialResult>? FinancialResults { get; set; }
    [JsonIgnore]
    public virtual ICollection<FinancialResultFinancialService>? FinancialResultsFinancialServices { get; set; }
}