namespace Efficiency.Data.DTO.ServiceResult;

public class GetServiceResultDTO
{
    public int ID { get; set; }
    public decimal Value { get; set; }
    public Models.Result? Result { get; set; }
    public Models.Service? Service { get; set; }
}