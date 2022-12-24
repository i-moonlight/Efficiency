using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.FinancialResult;

public class PutFinancialResultDTO
{
    public int ID { get; set; }
    public DateTime Date { get; set; }
    public decimal ProductSalesResult { get; set; }
}