using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.FinancialResult;

public class PostFinancialResultDTO
{
    [Required(ErrorMessage = "Financial Result's date is not optional")]
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "Financial Result's product sale result is not optional")]
    public decimal ProductSalesResult { get; set; }
}