using Efficiency.Data.DTO.User;
using Efficiency.Models;

namespace Efficiency.Data.DTO.Store;

public class GetStoreDTO
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? Street { get; set; }
    public string? District { get; set; }
    public string? Complement { get; set; }
    public string? Observations { get; set; }
    public string? ZipCode { get; set; }
}