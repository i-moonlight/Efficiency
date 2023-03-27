using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.ServiceGoal;

public class PutServiceGoalDTO
{
    [Required(ErrorMessage = "Service goal value is required")]
    public decimal? Value { get; set; }
    [Required(ErrorMessage = "Service ID is required")]
    public int? ServiceID { get; set; }
    [Required(ErrorMessage = "Goal ID is required")]
    public int? GoalID { get; set; }
}