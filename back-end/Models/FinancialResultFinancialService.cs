namespace Efficiency.Models;

public class FinancialResultFinancialService
{
    public decimal Result { get; set; }
    public int FinancialResultID { get; set; }
    public virtual FinancialResult FinancialResult { get; set; }
    public int FinancialServiceID { get; set; }
    public virtual FinancialService FinancialService { get; set; }
}