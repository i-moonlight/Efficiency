using AutoMapper;
using Efficiency.Data.DTO.User;
using Efficiency.Models;

namespace Efficiency.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, GetUserDTO>();
        CreateMap<PostUserDTO, User>();
    }
}