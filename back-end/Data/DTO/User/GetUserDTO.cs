namespace Efficiency.Data.DTO.User;

public class GetUserDTO
{
    public string? ID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
    public Models.Store? Store { get; set; }

}