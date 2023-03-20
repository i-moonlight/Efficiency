using System.ComponentModel.DataAnnotations;
using Efficiency.Models;

namespace Efficiency.Data.DTO.Goal;

public class PutGoalDTO
{
    [Required (ErrorMessage = "Goal ID is mandatory")]
    public int ID { get; set; }
    public double Value { get; set; }
    public Month Month { get; set; }    
    public int Year { get; set; }    
    public int? StoreID { get; set; }
    public int? ServiceID { get; set; }
}