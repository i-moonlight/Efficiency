using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.Store;

public class PostStoreDTO
{
    [Required(ErrorMessage = "Store name is mandatory")]
    public string? Name { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? ZipCode { get; set; }
}