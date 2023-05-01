using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.Seller;

public class PostSellerDTO
{
    public int RegistrationNumber { get; set; }

    [Required(ErrorMessage = "First name is not optional")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last name is not optional")]
    public string? LastName { get; set; }

    public string? Phone { get; set; }
    public string? Email { get; set; }

    [Required(ErrorMessage = "StoreID is mandatory")]
    public int? StoreID { get; set; }
}