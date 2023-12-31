using System.ComponentModel.DataAnnotations;
using Efficiency.Models;

namespace Efficiency.Data.DTO.User;

public class GetUserDTO
{
    public string? ID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    public string? Role { get; set; }
    public Subscription Subscription { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? SubscriptionBegin { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime? SubscriptionExpiration { get; set; }
    public int? StoreID { get; set; }
}