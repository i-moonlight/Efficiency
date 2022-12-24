using Efficiency.Models;

namespace Efficiency.Data.DTO.Company;

public class GetCompanyDTO
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public ICollection<Models.User>? Users { get; set; }
    public ICollection<Models.Employee>? Employees { get; set; }
}