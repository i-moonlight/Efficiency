using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.Company;

public class PutCompanyDTO
{
    [Required(ErrorMessage = "Company's ID is not optional")]
    public int ID { get; set; }
    [Required(ErrorMessage = "Company's name is not optional")]
    public string? Name { get; set; }
}