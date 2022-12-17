namespace Efficiency.Data.DTO.User;

public class GetUserDTO
{
    public int ID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
    public int? CompanyID { get; set; }

}