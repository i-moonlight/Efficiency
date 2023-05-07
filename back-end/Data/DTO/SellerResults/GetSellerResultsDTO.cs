using Efficiency.Data.DTO.Result;

namespace Efficiency.Data.DTO.SellerResults;

public class GetSellerResultsDTO
{
    public int? SellerID { get; set; }
    public ICollection<GetResultDTO>? Results { get; set; }
}