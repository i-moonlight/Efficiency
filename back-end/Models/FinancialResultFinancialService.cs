namespace Efficiency.Models;

public class FinancialResultFinancialService
{
    public decimal Result { get; set; }
    public int FinancialResultID { get; set; }
    public FinancialResult FinancialResult { get; set; }
    public int FinancialServiceID { get; set; }
    public FinancialService FinancialService { get; set; }
}