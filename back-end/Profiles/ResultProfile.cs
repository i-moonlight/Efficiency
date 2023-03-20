using AutoMapper;
using Efficiency.Data.DTO.Result;
using Efficiency.Models;

namespace Efficiency.Profiles;

public class ResultProfile : Profile
{
    public ResultProfile()
    {
        CreateMap<Result, GetResultDTO>();
        CreateMap<PostResultDTO, Result>();
        CreateMap<PutResultDTO, Result>();
    }   
}