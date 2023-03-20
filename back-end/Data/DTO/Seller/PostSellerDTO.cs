using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.Seller;

public class PostSellerDTO
{
    [Required(ErrorMessage = "Registration number is mandatory")]
    public int RegistrationNumber { get; set; }

    [Required(ErrorMessage = "First name is not optional")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last name is not optional")]
    public string? LastName { get; set; }

    public string? Phone { get; set; }
    public string? Email { get; set; }

    [Required(ErrorMessage = "Store reference is not optional")]
    public int? StoreID { get; set; }   
}