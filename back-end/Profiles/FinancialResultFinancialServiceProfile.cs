using AutoMapper;
using Efficiency.Data.DTO.FinancialResultFinancialService;
using Efficiency.Models;

namespace Efficiency.Profiles;

public class FinancialResultFinancialServiceProfile : Profile
{
    public FinancialResultFinancialServiceProfile()
    {
        CreateMap<FinancialResultFinancialService, GetFinancialResultFinancialServiceDTO>();
        CreateMap<PostFinancialResultFinancialServiceDTO, FinancialResultFinancialService>();
        CreateMap<PutFinancialResultFinancialServiceDTO, FinancialResultFinancialService>();
    }   
}