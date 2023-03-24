using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Efficiency.Models;

public class Result
{
    [Key]
    public int ID { get; set; }
    public DateOnly Date { get; set; }
    public decimal Value { get; set; }
    
    [JsonIgnore]
    public virtual Seller? Seller { get; set; }
    public int SellerID { get; set; }

    [JsonIgnore]
    public virtual ICollection<ServiceResult>? ResultsServices { get; set; }
}