using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.Store;

public class PutStoreDTO
{
    [Required(ErrorMessage = "Store ID is mandatory")]
    public int ID { get; set; }
    [Required(ErrorMessage = "Store name is mandatory")]
    public string? Name { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? ZipCode { get; set; }
}