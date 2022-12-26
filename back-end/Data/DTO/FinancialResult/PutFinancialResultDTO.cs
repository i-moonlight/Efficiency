using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.FinancialResult;

public class PutFinancialResultDTO
{
    [Required(ErrorMessage = "The Financial Result's ID is not optional")]
    public int ID { get; set; }
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "The Financial Result's product sales result is not optional")]
    [Range(0, 10000000, ErrorMessage = "The product sales result needs to be a decimal number between 0,00 and 10.000.000,00")]
    public decimal ProductSalesResult { get; set; }
}