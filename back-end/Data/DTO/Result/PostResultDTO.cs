using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.Result;

public class PostResultDTO
{
    [Required(ErrorMessage = "Result date is mandatory")]
    public DateTime DateTime { get; set; }
    public DateOnly Date { get; set; }

    [Required(ErrorMessage = "Result value is mandatory")]
    [Range(0, 100000000, ErrorMessage = "The sale results needs to be a decimal number between 0,00 and 100.000.000,00")]
    public decimal Value { get; set; }

    [Required(ErrorMessage = "SellerID is mandatory")]
    public int SellerID { get; set; }
}