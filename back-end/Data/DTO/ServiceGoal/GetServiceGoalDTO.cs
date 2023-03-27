namespace Efficiency.Data.DTO.ServiceGoal;

public class GetServiceGoalDTO
{
    public int? ID { get; set; }
    public decimal? Value { get; set; }
    public Models.Service? Service { get; set; }
    public Models.Goal? Goal { get; set; }
}