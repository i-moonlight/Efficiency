using Efficiency.Models;

namespace Efficiency.Data.DTO.Service;

public class GetServiceDTO
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<Models.Result>? Results { get; set; }
}