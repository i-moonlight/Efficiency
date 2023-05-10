using AutoMapper;
using Efficiency.Models;
using Efficiency.Data.DTO.ServiceGoal;
using Efficiency.Data.DTO.Service;

namespace Efficiency.Services;

public class ServiceGoalService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }
    private GoalService _goalService { get; set; }
    private ServiceService _serviceService { get; set; }

    public ServiceGoalService(AppDbContext context, IMapper mapper, ServiceService serviceService, GoalService goalService)
    {
        _context = context;
        _mapper = mapper;
        _serviceService = serviceService;
        _goalService = goalService;
    }

    public ICollection<GetServiceGoalDTO>? GetAll(int skip, int take)
    {
        ICollection<ServiceGoal>? servicesGoal = _context.ServicesGoal?
            .Skip(skip)
            .Take(take == 0 ? this._context.ServicesGoal.Count() : take)
            .ToList();
        ICollection<GetServiceGoalDTO>? DTO = _mapper.Map<ICollection<GetServiceGoalDTO>>(servicesGoal);
        return DTO;
    }

    public GetServiceGoalDTO? Get(int serviceID, int goalID)
    {
        ServiceGoal? serviceGoal = _context.ServicesGoal?.FirstOrDefault(
            serviceGoal =>
                serviceGoal.ServiceID == serviceID
                && serviceGoal.GoalID == goalID
        );
        GetServiceGoalDTO? DTO = _mapper.Map<GetServiceGoalDTO>(serviceGoal);

        return DTO;
    }

    public GetServiceGoalDTO? Post(PostServiceGoalDTO DTO)
    {
        GetServiceGoalDTO? result = null;

        ServiceGoal? serviceGoal = _mapper.Map<ServiceGoal>(DTO);

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

        if (serviceGoal != null)
        {
            _mapper.Map(DTO, serviceGoal);
            _context.SaveChanges();
            result = true;
        }

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
            result = true;
        }

        return result;
    }

    public ICollection<GetServiceDTO>? GetGoalServices(int goalID)
    {
        List<int> servicesIDs = new List<int>();

        ICollection<Service> services =
            (from serviceGoal in this._context.ServicesGoal
             where serviceGoal.GoalID == goalID
             select serviceGoal.Service).ToList();

        return this._mapper.Map<ICollection<GetServiceDTO>>(services);
    }
}