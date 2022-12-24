using AutoMapper;
using Efficiency.Data.DTO.EmployeeFinancialResult;
using Efficiency.Models;

namespace Efficiency.Profiles;

public class EmployeeFinancialResultProfile : Profile
{
    public EmployeeFinancialResultProfile()
    {
        CreateMap<EmployeeFinancialResult, GetEmployeeFinancialResultDTO>();
        CreateMap<PostEmployeeFinancialResultDTO, EmployeeFinancialResult>();
        CreateMap<PutEmployeeFinancialResultDTO, EmployeeFinancialResult>();
    }   
}