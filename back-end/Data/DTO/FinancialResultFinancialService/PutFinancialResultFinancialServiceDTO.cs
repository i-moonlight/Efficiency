using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.FinancialResultFinancialService;

public class PutFinancialResultFinancialServiceDTO
{
    [Required(ErrorMessage = "The ID is not optional")]
    public int ID { get; set; }
    [Required(ErrorMessage = "The financial service's result is not optional")]
    [Range(0, 10000000, ErrorMessage = "The financial service's result needs to be a decimal number between 0,00 and 10.000.000,00")]
    public decimal Result { get; set; }
    [Required(ErrorMessage = "Financial Result's ID is not optional")]
    public int FinancialResultID { get; set; }
    [Required(ErrorMessage = "Financial Service's ID is not optional")]
    public int FinancialServiceID { get; set; }
}