using AutoMapper;
using Efficiency.Data.DTO.SellerServiceResult;
using Efficiency.Data.DTO.Service;
using Efficiency.Data.DTO.ServiceResult;
using Efficiency.Data.Requests;
using Efficiency.Models;
using Efficiency.Models.Enums;

namespace Efficiency.Services;

public class ServiceResultService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }
    private ResultService _resultService { get; set; }
    private ServiceService _serviceService { get; set; }

    public ServiceResultService(AppDbContext context, IMapper mapper, ServiceService serviceService, ResultService resultService)
    {
        _context = context;
        _mapper = mapper;
        _serviceService = serviceService;
        _resultService = resultService;
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

    public ICollection<GetServiceDTO>? GetResultServices(int resultID)
    {
        List<int> servicesIDs = new List<int>();

        IQueryable<ServiceResult> sr =
            from serviceResult in this._context.ServicesResult
            where serviceResult.ResultID == resultID
            select serviceResult;

        foreach (var serviceResult in sr)
        {
            servicesIDs.Add(serviceResult.ServiceID);
        }

        ICollection<GetServiceDTO>? services = this._serviceService.GetBulkServices(servicesIDs);

        return services;
    }

    public ICollection<GetSellerServiceResultDTO>? GetBulkSellerServiceResult(List<int> sellersIDs, int year, int quarter, Month? month, int day)
    {
        ICollection<GetSellerServiceResultDTO>? results = null;

        if (sellersIDs.Count > 0)
        {
            if (year == 0 || year > DateTime.MaxValue.Year)
                results = this.GetBulkAllTimeSellerServiceResult(sellersIDs);
            else if (quarter > 0 && quarter < 4)
                results = this.GetBulkQuarterSellerServiceResult(sellersIDs, year, quarter);
            else if (month != null)
                if (day > 0 && day < 31)
                    results = this.GetBulkDaySellerServiceResult(
                            sellersIDs,
                            DateOnly.FromDateTime(new DateTime(year, ((int)month), day))
                        );
                else
                    results = this.GetBulkMonthSellerServiceResult(sellersIDs, year, ((int)month));
            else
                results = this.GetBulkYearSellerServiceResult(sellersIDs, year);
        }

        return results;
    }

    public ICollection<GetSellerServiceResultDTO>? GetBulkDaySellerServiceResult(List<int> sellersIDs, DateOnly date)
    {
        ICollection<GetSellerServiceResultDTO> sellerServicesResults = new List<GetSellerServiceResultDTO>();

        foreach (var sellerID in sellersIDs)
        {
            ICollection<ServiceResult> sr = (
                from servicesresults in this._context.ServicesResult
                where
                    servicesresults.Result != null
                    && servicesresults.Result.SellerID == sellerID
                    && servicesresults.Result.Date == date
                select servicesresults
            ).ToList();

            GetSellerServiceResultDTO dto = new GetSellerServiceResultDTO()
            {
                SellerID = sellerID,
                ServiceResults = this._mapper.Map<ICollection<GetServiceResultDTO>>(sr)
            };

            if (sr.Count > 0)
                sellerServicesResults.Add(dto);
        }

        return sellerServicesResults;
    }

    public ICollection<GetSellerServiceResultDTO>? GetBulkMonthSellerServiceResult(List<int> sellersIDs, int year, int month)
    {
        ICollection<GetSellerServiceResultDTO> sellerServicesResults = new List<GetSellerServiceResultDTO>();

        foreach (var sellerID in sellersIDs)
        {
            ICollection<ServiceResult> sr = (
                from servicesresults in this._context.ServicesResult
                where
                    servicesresults.Result != null
                    && servicesresults.Result.SellerID == sellerID
                    && servicesresults.Result.Date.Year == year
                    && servicesresults.Result.Date.Month == month
                select servicesresults
            ).ToList();

            GetSellerServiceResultDTO dto = new GetSellerServiceResultDTO()
            {
                SellerID = sellerID,
                ServiceResults = this._mapper.Map<ICollection<GetServiceResultDTO>>(sr)
            };

            if (sr.Count > 0)
                sellerServicesResults.Add(dto);
        }

        return sellerServicesResults;
    }

    public ICollection<GetSellerServiceResultDTO>? GetBulkQuarterSellerServiceResult(List<int> sellersIDs, int year, int quarter)
    {
        ICollection<GetSellerServiceResultDTO> sellerServicesResults = new List<GetSellerServiceResultDTO>();

        foreach (var sellerID in sellersIDs)
        {
            ICollection<ServiceResult> sr = (
                from servicesresults in this._context.ServicesResult
                where
                    servicesresults.Result != null
                    && servicesresults.Result.SellerID == sellerID
                    && servicesresults.Result.Date.Year == year
                    && Math.Ceiling(servicesresults.Result.Date.Month / 3.0) == quarter
                select servicesresults
            ).ToList();

            GetSellerServiceResultDTO dto = new GetSellerServiceResultDTO()
            {
                SellerID = sellerID,
                ServiceResults = this._mapper.Map<ICollection<GetServiceResultDTO>>(sr)
            };

            if (sr.Count > 0)
                sellerServicesResults.Add(dto);
        }

        return sellerServicesResults;
    }

    public ICollection<GetSellerServiceResultDTO>? GetBulkYearSellerServiceResult(List<int> sellersIDs, int year)
    {
        ICollection<GetSellerServiceResultDTO> sellerServicesResults = new List<GetSellerServiceResultDTO>();

        foreach (var sellerID in sellersIDs)
        {
            ICollection<ServiceResult> sr = (
                from servicesresults in this._context.ServicesResult
                where
                    servicesresults.Result != null
                    && servicesresults.Result.SellerID == sellerID
                    && servicesresults.Result.Date.Year == year
                select servicesresults
            ).ToList();

            GetSellerServiceResultDTO dto = new GetSellerServiceResultDTO()
            {
                SellerID = sellerID,
                ServiceResults = this._mapper.Map<ICollection<GetServiceResultDTO>>(sr)
            };

            if (sr.Count > 0)
                sellerServicesResults.Add(dto);
        }

        return sellerServicesResults;
    }

    public ICollection<GetSellerServiceResultDTO>? GetBulkAllTimeSellerServiceResult(List<int> sellersIDs)
    {
        ICollection<GetSellerServiceResultDTO> sellerServicesResults = new List<GetSellerServiceResultDTO>();

        foreach (var sellerID in sellersIDs)
        {
            ICollection<ServiceResult> sr = (
                from servicesresults in this._context.ServicesResult
                where
                    servicesresults.Result != null
                    && servicesresults.Result.SellerID == sellerID
                select servicesresults
            ).ToList();

            GetSellerServiceResultDTO dto = new GetSellerServiceResultDTO()
            {
                SellerID = sellerID,
                ServiceResults = this._mapper.Map<ICollection<GetServiceResultDTO>>(sr)
            };

            if (sr.Count > 0)
                sellerServicesResults.Add(dto);
        }

        return sellerServicesResults;
    }

}