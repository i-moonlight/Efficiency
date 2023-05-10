using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Efficiency.Models;

public class Service
{
    [Key]
    public int ID { get; set; }
    public string? Name { get; set; }

    [JsonIgnore]
    public int StoreID { get; set; }
    [JsonIgnore]
    public virtual Store? Store { get; set; }
    [JsonIgnore]
    public virtual ICollection<ServiceResult>? ServicesResult { get; set; }
    [JsonIgnore]
    public virtual ICollection<ServiceGoal>? ServicesGoal { get; set; }
}