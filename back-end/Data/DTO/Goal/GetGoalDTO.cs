using Efficiency.Models;
using Efficiency.Models.Enums;

namespace Efficiency.Data.DTO.Goal;

public class GetGoalDTO
{
    public int ID { get; set; }
    public double Value { get; set; }
    public Month Month { get; set; }
    public int Year { get; set; }
    public int? StoreID { get; set; }
}