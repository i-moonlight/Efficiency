using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.ServiceResult;

public class PostServiceResultDTO
{
    [Required(ErrorMessage = "Service result value is required")]
    public decimal? Value { get; set; }
    [Required(ErrorMessage = "Service ID is required")]
    public int? ServiceID { get; set; }
    [Required(ErrorMessage = "Result ID is required")]
    public int? ResultID { get; set; }
}