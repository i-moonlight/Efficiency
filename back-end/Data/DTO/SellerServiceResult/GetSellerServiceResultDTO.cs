using Efficiency.Data.DTO.ServiceResult;

namespace Efficiency.Data.DTO.SellerServiceResult;

public class GetSellerServiceResultDTO
{
    public int? SellerID { get; set; }
    public ICollection<GetServiceResultDTO>? ServiceResults { get; set; }
}