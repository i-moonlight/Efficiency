using Efficiency.Models;

namespace Efficiency.Data.DTO.FinancialService;

public class GetFinancialServiceDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<Models.FinancialResult>? FinancialResults { get; set; }
    public virtual ICollection<Models.FinancialResultFinancialService>? FinancialResultsFinancialServices { get; set; }
}