using System.ComponentModel.DataAnnotations;

namespace Efficiency.Data.DTO.EmployeeFinancialResult;

public class PutEmployeeFinancialResultDTO
{
    public int ID { get; set; }
    public int EmployeeID { get; set; }
    public int FinancialResultID { get; set; }
}