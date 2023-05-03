using System.Text.Json.Serialization;

namespace Efficiency.Models;

public class ServiceResult
{
    public decimal Value { get; set; }
    public int ResultID { get; set; }
    public int ServiceID { get; set; }

    [JsonIgnore]
    public virtual Result? Result { get; set; }
    [JsonIgnore]
    public virtual Service? Service { get; set; }
}