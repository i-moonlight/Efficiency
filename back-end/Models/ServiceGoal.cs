using System.Text.Json.Serialization;

namespace Efficiency.Models;

public class ServiceGoal
{
    public decimal Value { get; set; }
    public int GoalID { get; set; }
    public int ServiceID { get; set; }

    [JsonIgnore]
    public virtual Service? Service { get; set; }
    [JsonIgnore]
    public virtual Goal? Goal { get; set; }
}