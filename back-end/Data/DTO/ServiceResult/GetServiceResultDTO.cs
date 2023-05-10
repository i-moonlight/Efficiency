namespace Efficiency.Data.DTO.ServiceResult;

public class GetServiceResultDTO
{
    public decimal Value { get; set; }
    public Models.Result? Result { get; set; }
    public Models.Service? Service { get; set; }
}