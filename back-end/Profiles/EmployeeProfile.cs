using AutoMapper;
using Efficiency.Data.DTO.Employee;
using Efficiency.Models;

namespace Efficiency.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, GetEmployeeDTO>();
        CreateMap<PostEmployeeDTO, Employee>();
        CreateMap<PutEmployeeDTO, Employee>();
    }   
}