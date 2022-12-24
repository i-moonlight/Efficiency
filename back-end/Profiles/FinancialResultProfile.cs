using AutoMapper;
using Efficiency.Data.DTO.FinancialResult;
using Efficiency.Models;

namespace Efficiency.Profiles;

public class FinancialResultProfile : Profile
{
    public FinancialResultProfile()
    {
        CreateMap<FinancialResult, GetFinancialResultDTO>();
        CreateMap<PostFinancialResultDTO, FinancialResult>();
        CreateMap<PutFinancialResultDTO, FinancialResult>();
    }   
}