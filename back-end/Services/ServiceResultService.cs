using AutoMapper;
using Efficiency.Data.DTO.ServiceResult;
using Efficiency.Models;

namespace Efficiency.Services;

public class ServiceResultService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public ServiceResultService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<GetServiceResultDTO>? GetAll()
    {
        ICollection<ServiceResult>? servicesResult = _context.ServicesResult?.ToList();
        ICollection<GetServiceResultDTO>? DTO = _mapper.Map<ICollection<GetServiceResultDTO>>(servicesResult);
        return DTO;
    }

    public GetServiceResultDTO? Get(int serviceID, int ResultID)
    {
        ServiceResult? serviceResult = _context.ServicesResult?.FirstOrDefault(
            serviceResult => serviceResult.ServiceID == serviceID
                && serviceResult.ResultID == ResultID
        );
        GetServiceResultDTO? DTO = _mapper.Map<GetServiceResultDTO>(serviceResult);

        return DTO;
    }

    public GetServiceResultDTO? Post(PostServiceResultDTO DTO)
    {
        GetServiceResultDTO? result = null;

        ServiceResult serviceResult = _mapper.Map<ServiceResult>(DTO);

        _context.Add(serviceResult);
        _context.SaveChanges();

        result = _mapper.Map<GetServiceResultDTO>(serviceResult);

        return result;
    }

    public bool Put(PutServiceResultDTO DTO)
    {
        bool result = false;

        ServiceResult? serviceResult = _context.ServicesResult?.FirstOrDefault(
            serviceResult => serviceResult.ResultID == DTO.ResultID
                && serviceResult.ServiceID == DTO.ServiceID
        );

        _mapper.Map(DTO, serviceResult);
        _context.SaveChanges();

        return result;
    }

    public bool Delete(int serviceID, int ResultID)
    {
        bool result = false;

        ServiceResult? serviceResult = _context.ServicesResult?.FirstOrDefault(
            serviceResult => serviceResult.ResultID == ResultID
                && serviceResult.ServiceID == serviceID
        );

        if (serviceResult != null)
        {
            _context.ServicesResult?.Remove(serviceResult);
            _context.SaveChanges();
        }

        return result;
    }
}