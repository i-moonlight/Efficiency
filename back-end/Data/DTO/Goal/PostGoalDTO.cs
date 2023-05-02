using System.ComponentModel.DataAnnotations;
using Efficiency.Models;
using Efficiency.Models.Enums;

namespace Efficiency.Data.DTO.Goal;

public class PostGoalDTO
{
    [Required(ErrorMessage = "Goal value is mandatory")]
    public double Value { get; set; }

    [Required(ErrorMessage = "Month is mandatory")]
    public Month Month { get; set; }

    [Required(ErrorMessage = "Year is mandatory")]
    public int Year { get; set; }

    [Required(ErrorMessage = "StoreID is mandatory")]
    public int? StoreID { get; set; }
}