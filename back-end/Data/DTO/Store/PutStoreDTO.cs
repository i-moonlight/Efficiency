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
    [StringLength(100)]
    public string? Street { get; set; }
    [StringLength(100)]
    public string? District { get; set; }
    [StringLength(100)]
    public string? Complement { get; set; }
    [StringLength(100)]
    public string? Observations { get; set; }
    [StringLength(10)]
    public string? ZipCode { get; set; }
}