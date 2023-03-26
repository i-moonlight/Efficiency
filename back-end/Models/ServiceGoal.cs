namespace Efficiency.Models;

public class ServiceGoal
{
    public int ServiceID { get; set; }
    public virtual Service? Service { get; set; }
    public int GoalID { get; set; }
    public virtual Goal? Goal { get; set; }
}