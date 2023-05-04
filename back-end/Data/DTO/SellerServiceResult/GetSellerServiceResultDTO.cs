namespace Efficiency.Data.DTO.SellerServiceResult;

public class GetSellerServiceResultDTO
{
    public int? SellerID { get; set; }
    public ICollection<Models.ServiceResult>? ServiceResults { get; set; }
    public double? Total { get; set; }
}