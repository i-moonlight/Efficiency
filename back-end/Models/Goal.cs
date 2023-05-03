using System.Text.Json.Serialization;
using Efficiency.Models.Enums;

namespace Efficiency.Models;

public class Goal
{
    public int ID { get; set; }
    public double Value { get; set; }
    public Month Month { get; set; }
    public int Year { get; set; }

    [JsonIgnore]
    public int? StoreID { get; set; }

    [JsonIgnore]
    public virtual Store? Store { get; set; }

    [JsonIgnore]
    public virtual ICollection<ServiceGoal>? ServicesGoal { get; set; }
}