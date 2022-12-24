using AutoMapper;
using Efficiency.Data.DTO.FinancialService;
using Efficiency.Models;

namespace Efficiency.Profiles;

public class FinancialServiceProfile : Profile
{
    public FinancialServiceProfile()
    {
        CreateMap<FinancialService, GetFinancialServiceDTO>();
        CreateMap<PostFinancialServiceDTO, FinancialService>();
        CreateMap<PutFinancialServiceDTO, FinancialService>();
    }   
}