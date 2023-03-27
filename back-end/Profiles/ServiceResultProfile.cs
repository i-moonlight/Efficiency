using AutoMapper;
using Efficiency.Models;
using Efficiency.Data.DTO.ServiceResult;

namespace Efficiency.Profiles;

public class ServiceResultProfile : Profile
{
    public ServiceResultProfile()
    {
        CreateMap<ServiceResult, GetServiceResultDTO>();
        CreateMap<PostServiceResultDTO, ServiceResult>();
        CreateMap<PutServiceResultDTO, ServiceResult>();
    }
}