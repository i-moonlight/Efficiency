using Efficiency.Models;

namespace Efficiency.Data.DTO.Service;

public class GetServiceDTO
{
    public int ID { get; set; }
    public string? Name { get; set; }

    public Models.Store? Store { get; set; }
    public ICollection<Models.ServiceResult>? ServicesResult { get; set; }
    public ICollection<Models.ServiceGoal>? ServicesGoal { get; set; }
}