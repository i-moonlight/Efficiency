using Efficiency.Models;

namespace Efficiency.Data.DTO.Store;

public class GetStoreDTO
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? ZipCode { get; set; }
    public ICollection<Models.User>? Users { get; set; }
    public ICollection<Models.Seller>? Sellers { get; set; }
    public virtual ICollection<Models.Goal>? Goals { get; set; }
}