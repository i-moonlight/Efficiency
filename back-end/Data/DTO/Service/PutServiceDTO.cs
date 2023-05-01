using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.Service;

public class PutServiceDTO
{
    [Required(ErrorMessage = "The ServiceID is mandatory")]
    public int ID { get; set; }

    [Required(ErrorMessage = "The name of the service is mandatory")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "StoreID is mandatory")]
    public int? StoreID { get; set; }
}