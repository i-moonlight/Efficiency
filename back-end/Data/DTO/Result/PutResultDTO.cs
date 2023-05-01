using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.Result;

public class PutResultDTO
{
    [Required(ErrorMessage = "The Financial Result's ID is not optional")]
    public int ID { get; set; }

    [Required(ErrorMessage = "The result date is mandatory")]
    public DateOnly Date { get; set; }

    [Required(ErrorMessage = "The sales result is not optional")]
    [Range(0, 100000000, ErrorMessage = "The product sales result needs to be a decimal number between 0,00 and 100.000.000,00")]
    public decimal Value { get; set; }

    [Required(ErrorMessage = "The Seller ID is mandatory")]
    public int SellerID { get; set; }
}