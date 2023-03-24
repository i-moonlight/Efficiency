namespace Efficiency.Models;

public class ServiceResult
{
    public int ResultID { get; set; }
    public virtual Result? Result { get; set; }
    public int ServiceID { get; set; }
    public virtual Service? Service { get; set; }
    public decimal Value { get; set; }
}