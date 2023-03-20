using AutoMapper;
using Efficiency.Data.DTO.Service;
using Efficiency.Models;

namespace Efficiency.Profiles;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Service, GetServiceDTO>();
        CreateMap<PostServiceDTO, Service>();
        CreateMap<PutServiceDTO, Service>();
    }   
}