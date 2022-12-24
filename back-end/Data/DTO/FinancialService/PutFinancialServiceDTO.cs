using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.FinancialService;

public class PutFinancialServiceDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
}