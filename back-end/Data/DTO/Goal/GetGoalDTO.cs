using Efficiency.Models;
using Efficiency.Models.Enums;

namespace Efficiency.Data.DTO.Goal;

public class GetGoalDTO
{
    public int ID { get; set; }
    public double Value { get; set; }
    public Month Month { get; set; }
    public int Year { get; set; }
    public Models.Store? Store { get; set; }
    public Models.Service? Service { get; set; }

    public ICollection<Models.ServiceGoal>? ServicesGoal { get; set; }
}