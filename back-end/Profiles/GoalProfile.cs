using AutoMapper;
using Efficiency.Data.DTO.Goal;
using Efficiency.Models;

namespace Efficiency.Profiles;

public class GoalProfile : Profile
{
    public GoalProfile()
    {
        CreateMap<Goal, GetGoalDTO>();
        CreateMap<PostGoalDTO, Goal>();
        CreateMap<PutGoalDTO, Goal>();
    }   
}