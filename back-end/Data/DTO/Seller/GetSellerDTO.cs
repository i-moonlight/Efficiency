using Efficiency.Models;

namespace Efficiency.Data.DTO.Seller;

public class GetSellerDTO
{
    public int ID { get; set; }
    public int RegistrationNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool? Active { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public Models.Store? Store { get; set; }
    public ICollection<Models.Result>? Results { get; set; }
}