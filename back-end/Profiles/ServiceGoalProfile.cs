using AutoMapper;
using Efficiency.Models;
using Efficiency.Data.DTO.ServiceGoal;

namespace Efficiency.Profiles;

public class ServiceGoalProfile : Profile
{
    public ServiceGoalProfile()
    {
        CreateMap<ServiceGoal, GetServiceGoalDTO>();
        CreateMap<PostServiceGoalDTO, ServiceGoal>();
        CreateMap<PutServiceGoalDTO, ServiceGoal>();
    }
}