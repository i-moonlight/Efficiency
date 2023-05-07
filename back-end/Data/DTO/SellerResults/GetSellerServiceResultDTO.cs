using Efficiency.Data.DTO.ServiceResult;

namespace Efficiency.Data.DTO.SellerResults;

public class GetSellerServiceResultDTO
{
    public int? SellerID { get; set; }
    public ICollection<GetServiceResultDTO>? ServiceResults { get; set; }
}