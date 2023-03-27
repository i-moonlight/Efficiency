using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.Result;

public class PostResultDTO
{
    [Required(ErrorMessage = "Result date is mandatory")]
    public DateOnly Date { get; set; }

    [Required(ErrorMessage = "Result value is not optional")]
    [Range(0, 10000000, ErrorMessage = "The sale results needs to be a decimal number between 0,00 and 10.000.000,00")]
    public decimal Value { get; set; }

    [Required(ErrorMessage = "Seller ID is not optional")]
    public int SellerID { get; set; }
}