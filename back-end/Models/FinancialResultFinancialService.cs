using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Efficiency.Models;

public class FinancialResultFinancialService
{
    [Key]
    public int ID { get; set; }
    public decimal Result { get; set; }
    [JsonIgnore]
    public int FinancialResultID { get; set; }
    [JsonIgnore]
    public virtual FinancialResult? FinancialResult { get; set; }
    [JsonIgnore]
    public int FinancialServiceID { get; set; }
    [JsonIgnore]
    public virtual FinancialService? FinancialService { get; set; }
}