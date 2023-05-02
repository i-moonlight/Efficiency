using AutoMapper;
using Efficiency.Data.DTO.Service;
using Efficiency.Models;

namespace Efficiency.Services;

public class ServiceService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public ServiceService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<GetServiceDTO> GetAll(int skip, int take)
    {
        return _mapper.Map<ICollection<GetServiceDTO>>(
            _context.Services?
                .Skip(skip)
                .Take(take)
                .ToList()
        );
    }

    public GetServiceDTO? Get(int ID)
    {
        return _mapper.Map<GetServiceDTO>(
            _context.Services?.FirstOrDefault(
                service => service.ID == ID
            )
        );
    }

    public GetServiceDTO? Post(PostServiceDTO ServiceDTO)
    {
        GetServiceDTO? result = null;
        Service? Service = _context.Services?.FirstOrDefault(
            service =>
                service.Name != null
                && ServiceDTO.Name != null
                && service.Name
                    .ToUpper()
                    .Equals(ServiceDTO.Name.ToUpper())
        );

        if (Service == null)
        {
            Service = _mapper.Map<Service>(Service);
            _context.Services?.Add(Service);
            _context.SaveChanges();
            result = _mapper.Map<GetServiceDTO>(Service);
        }

        return result;
    }

    public bool Put(PutServiceDTO ServiceDTO)
    {
        bool result = false;

        Service? Service = _context.Services?.FirstOrDefault(
            service => service.ID == ServiceDTO.ID
        );

        if (Service != null)
        {
            _mapper.Map(ServiceDTO, Service);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    public bool Delete(int ID)
    {
        bool result = false;

        Service? Service = _context.Services?.FirstOrDefault(
            service => service.ID == ID
        );

        if (Service != null)
        {
            _context.Remove(Service);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    private bool CheckExistingServiceByName(Service Service)
    {
        bool result = false;

        if (_context.Services != null)
        {
            var Services = _context.Services.ToList();
            foreach (var fService in Services)
            {
                if (!result && fService.Name != null && Service.Name != null)
                {
                    result = (fService.Name.ToUpper().Equals(Service.Name.ToUpper()));
                }
            }
            System.Console.WriteLine(result);
        }

        return result;
    }

    public ICollection<GetServiceDTO>? GetStoreServices(int storeID)
    {
        return this._mapper.Map<ICollection<GetServiceDTO>>
        (
            from service in this._context.Services
            where service.StoreID == storeID
            select service
        );
    }
}