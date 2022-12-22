using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.Company;

public class PostCompanyDTO
{
    [Required(ErrorMessage = "Company's name is not optional")]
    public string? Name { get; set; }
}