using AutoMapper;
using Efficiency.Data.DTO.ServiceGoal;
using Efficiency.Models;

namespace Efficiency.Services;

public class ServiceGoalService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public ServiceGoalService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<GetServiceGoalDTO>? GetAll()
    {
        ICollection<ServiceGoal>? servicesGoal = _context.ServicesGoal?.ToList();
        ICollection<GetServiceGoalDTO>? DTO = _mapper.Map<ICollection<GetServiceGoalDTO>>(servicesGoal);
        return DTO;
    }

    public GetServiceGoalDTO? Get(int serviceID, int goalID)
    {
        ServiceGoal? serviceGoal = _context.ServicesGoal?.FirstOrDefault(
            serviceGoal => serviceGoal.ServiceID == serviceID
                && serviceGoal.GoalID == goalID
        );
        GetServiceGoalDTO? DTO = _mapper.Map<GetServiceGoalDTO>(serviceGoal);

        return DTO;
    }

    public GetServiceGoalDTO? Post(PostServiceGoalDTO DTO)
    {
        GetServiceGoalDTO? result = null;

        ServiceGoal serviceGoal = _mapper.Map<ServiceGoal>(DTO);

        _context.Add(serviceGoal);
        _context.SaveChanges();

        result = _mapper.Map<GetServiceGoalDTO>(serviceGoal);

        return result;
    }

    public bool Put(PutServiceGoalDTO DTO)
    {
        bool result = false;

        ServiceGoal? serviceGoal = _context.ServicesGoal?.FirstOrDefault(
            serviceGoal => serviceGoal.GoalID == DTO.GoalID
                && serviceGoal.ServiceID == DTO.ServiceID
        );

        _mapper.Map(DTO, serviceGoal);
        _context.SaveChanges();

        return result;
    }

    public bool Delete(int serviceID, int goalID)
    {
        bool result = false;

        ServiceGoal? serviceGoal = _context.ServicesGoal?.FirstOrDefault(
            serviceGoal => serviceGoal.GoalID == goalID
                && serviceGoal.ServiceID == serviceID
        );

        if (serviceGoal != null)
        {
            _context.ServicesGoal?.Remove(serviceGoal);
            _context.SaveChanges();
        }

        return result;
    }
}