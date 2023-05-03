using Efficiency.Models;

namespace Efficiency.Data.DTO.Result;

public class GetResultDTO
{
    public int ID { get; set; }
    public DateOnly Date { get; set; }
    public decimal Value { get; set; }
    public Models.Seller? Seller { get; set; }
}