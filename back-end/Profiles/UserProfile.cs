using AutoMapper;
using Efficiency.Data.DTO.User;
using Efficiency.Models;
using Microsoft.AspNetCore.Identity;

namespace Efficiency.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, GetUserDTO>();
        CreateMap<GetUserDTO, User>();
        CreateMap<PostUserDTO, User>();
        CreateMap<PutUserDTO, User>();
    }
}