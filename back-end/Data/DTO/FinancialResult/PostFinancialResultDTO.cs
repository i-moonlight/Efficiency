using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.FinancialResult;

public class PostFinancialResultDTO
{
    [Required(ErrorMessage = "Financial Result's date is not optional")]
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "Financial Result's product sale result is not optional")]
    [Range(0, 10000000, ErrorMessage = "The product sale results needs to be a decimal number between 0,00 and 10.000.000,00")]
    public decimal ProductSalesResult { get; set; }
}