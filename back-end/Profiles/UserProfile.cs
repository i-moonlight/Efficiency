using AutoMapper;
using Efficiency.Data.DTO;
using Efficiency.Models;

namespace Efficiency.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, GetUserDTO>();
    }
}