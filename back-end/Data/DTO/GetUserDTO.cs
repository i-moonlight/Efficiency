namespace Efficiency.Data.DTO;

public class GetUserDTO
{
    public int UserID { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
    public int? CompanyID { get; set; }

}