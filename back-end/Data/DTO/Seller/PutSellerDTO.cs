using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.Seller;

public class PutSellerDTO
{
    [Required(ErrorMessage = "Seller ID is mandatory")]
    public int ID { get; set; }
    public int RegistrationNumber { get; set; }

    [Required(ErrorMessage = "Seller's First Name is not optional")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Seller's Last Name is not optional")]
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }

    [Required(ErrorMessage = "Seller's Store reference is not optional")]
    public int? StoreID { get; set; }
}