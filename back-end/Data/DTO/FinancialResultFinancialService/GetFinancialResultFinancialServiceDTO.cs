using Efficiency.Models;

namespace Efficiency.Data.DTO.FinancialResultFinancialService;

public class GetFinancialResultFinancialServiceDTO
{
    public int ID { get; set; }
    public decimal Result { get; set; }
    public virtual Models.FinancialResult? FinancialResult { get; set; }
    public virtual Models.FinancialService? FinancialService { get; set; }
}