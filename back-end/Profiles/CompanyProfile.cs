using AutoMapper;
using Efficiency.Data.DTO.Company;
using Efficiency.Models;

namespace Efficiency.Profiles;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<Company, GetCompanyDTO>();
        CreateMap<PostCompanyDTO, Company>();
        CreateMap<PutCompanyDTO, Company>();
    }   
}