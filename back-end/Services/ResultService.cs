using AutoMapper;
using Efficiency.Data.DTO.Result;
using Efficiency.Data.DTO.SellerResults;
using Efficiency.Models;
using Efficiency.Models.Enums;

namespace Efficiency.Services;

public class ResultService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public ResultService(
        AppDbContext context,
        IMapper mapper
    )
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<GetResultDTO> GetAll(int skip, int take)
    {
        return _mapper.Map<ICollection<GetResultDTO>>(
            _context.Results?
                .Skip(skip)
                .Take(take)
                .ToList()
        );
    }

    public GetResultDTO? Get(int ID)
    {
        return _mapper.Map<GetResultDTO>(
            _context.Results?.FirstOrDefault(
                result => result.ID == ID
            )
        );
    }

    public GetResultDTO? Post(PostResultDTO ResultDTO)
    {
        GetResultDTO? result = null;
        Result? Result = _context.Results?.FirstOrDefault(
            result => result.Date.CompareTo(ResultDTO.Date) == 0
                    && result.SellerID == ResultDTO.SellerID
        );

        // if Result is null, it means that no result 
        // with the informed date, seller and service 
        // was found, meaning we can add it to the 
        // database with no duplicates
        if (Result == null)
        {
            Result = _mapper.Map<Result>(ResultDTO);
            _context.Results?.Add(Result);
            _context.SaveChanges();
            // POST Result -> POST Service -> POST ServicesResults
            result = _mapper.Map<GetResultDTO>(Result);
        }

        return result;
    }

    public bool Put(PutResultDTO ResultDTO)
    {
        bool result = false;

        Result? Result = _context.Results?.FirstOrDefault(
            result => result.ID == ResultDTO.ID
        );

        if (Result != null)
        {
            _mapper.Map(ResultDTO, Result);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    public bool Delete(int ID)
    {
        bool result = false;

        Result? Result = _context.Results?.FirstOrDefault(
            result => result.ID == ID
        );

        if (Result != null)
        {
            _context.Remove(Result);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    public ICollection<GetSellerResultsDTO>? GetBulkSellersResults(
        List<int> sellersIDs,
        int year,
        Quarter? quarter,
        Month? month,
        int day
    )
    {
        ICollection<GetSellerResultsDTO>? results = null;

        if (sellersIDs.Count > 0)
        {
            if (year == 0 || year > DateTime.MaxValue.Year)
                results = this.GetBulkAllTimeSellerResult(sellersIDs);
            else if (quarter != null)
                results = this.GetBulkQuarterSellerResult(sellersIDs, year, (int)quarter);
            else if (month != null)
                if (day > 0 && day < 31)
                    results = this.GetBulkDaySellerResult(
                            sellersIDs,
                            DateOnly.FromDateTime(new DateTime(year, ((int)month), day))
                        );
                else
                    results = this.GetBulkMonthSellerResult(sellersIDs, year, ((int)month));
            else
                results = this.GetBulkYearSellerResult(sellersIDs, year);
        }

        return results;
    }

    private ICollection<GetSellerResultsDTO>? GetBulkDaySellerResult(
        List<int> sellersIDs,
        DateOnly dateOnly
    )
    {
        ICollection<GetSellerResultsDTO> sellersResults = new List<GetSellerResultsDTO>();

        foreach (var sellerID in sellersIDs)
        {
            ICollection<Result> results = (
                from result in this._context.Results
                where
                    result.SellerID == sellerID
                    && result.Date == dateOnly
                select result
            ).ToList();

            GetSellerResultsDTO dto = new GetSellerResultsDTO()
            {
                SellerID = sellerID,
                Results = this._mapper.Map<ICollection<GetResultDTO>>(results)
            };

            if (results.Count > 0)
                sellersResults.Add(dto);
        }

        return sellersResults;
    }

    private ICollection<GetSellerResultsDTO>? GetBulkMonthSellerResult(
        List<int> sellersIDs,
        int year,
        int month
    )
    {
        ICollection<GetSellerResultsDTO> sellersResults = new List<GetSellerResultsDTO>();

        foreach (var sellerID in sellersIDs)
        {
            ICollection<Result> results = (
                from result in this._context.Results
                where
                    result.SellerID == sellerID
                    && result.Date.Year == year
                    && result.Date.Month == month
                select result
            ).ToList();

            GetSellerResultsDTO dto = new GetSellerResultsDTO()
            {
                SellerID = sellerID,
                Results = this._mapper.Map<ICollection<GetResultDTO>>(results)
            };

            if (results.Count > 0)
                sellersResults.Add(dto);
        }

        return sellersResults;
    }

    private ICollection<GetSellerResultsDTO>? GetBulkQuarterSellerResult(
        List<int> sellersIDs,
        int year,
        int quarter
    )
    {
        ICollection<GetSellerResultsDTO> sellersResults = new List<GetSellerResultsDTO>();

        foreach (var sellerID in sellersIDs)
        {
            ICollection<Result> results = (
                from result in this._context.Results
                where
                    result.SellerID == sellerID
                    && result.Date.Year == year
                    && Math.Ceiling(result.Date.Month / 3.0) == quarter
                select result
            ).ToList();

            GetSellerResultsDTO dto = new GetSellerResultsDTO()
            {
                SellerID = sellerID,
                Results = this._mapper.Map<ICollection<GetResultDTO>>(results)
            };

            if (results.Count > 0)
                sellersResults.Add(dto);
        }

        return sellersResults;
    }

    private ICollection<GetSellerResultsDTO>? GetBulkYearSellerResult(
        List<int> sellersIDs,
        int year
    )
    {
        ICollection<GetSellerResultsDTO> sellersResults = new List<GetSellerResultsDTO>();

        foreach (var sellerID in sellersIDs)
        {
            ICollection<Result> results = (
                from result in this._context.Results
                where
                    result.SellerID == sellerID
                    && result.Date.Year == year
                select result
            ).ToList();

            GetSellerResultsDTO dto = new GetSellerResultsDTO()
            {
                SellerID = sellerID,
                Results = this._mapper.Map<ICollection<GetResultDTO>>(results)
            };

            if (results.Count > 0)
                sellersResults.Add(dto);
        }

        return sellersResults;
    }

    private ICollection<GetSellerResultsDTO>? GetBulkAllTimeSellerResult(List<int> sellersIDs)
    {
        ICollection<GetSellerResultsDTO> sellersResults = new List<GetSellerResultsDTO>();

        foreach (var sellerID in sellersIDs)
        {
            ICollection<Result> results = (
                from result in this._context.Results
                where
                    result.SellerID == sellerID
                select result
            ).ToList();

            GetSellerResultsDTO dto = new GetSellerResultsDTO()
            {
                SellerID = sellerID,
                Results = this._mapper.Map<ICollection<GetResultDTO>>(results)
            };

            if (results.Count > 0)
                sellersResults.Add(dto);
        }

        return sellersResults;
    }

    public GetSellerResultsDTO? GetSellerResults(
        int sellerID,
        int year,
        Quarter? quarter,
        Month? month,
        int day
    )
    {
        GetSellerResultsDTO? results = null;

        if (year == 0 || year > DateTime.Now.Year)
            results = this.GetAllTimeSellerResult(sellerID);
        else if (quarter != null)
            results = this.GetQuarterSellerResult(sellerID, year, (int)quarter);
        else if (month != null)
            if (day > 0 && day <= 31)
                results = this.GetDaySellerResult(
                        sellerID,
                        DateOnly.FromDateTime(new DateTime(year, ((int)month), day))
                    );
            else
                results = this.GetMonthSellerResult(sellerID, year, ((int)month));
        else
            results = this.GetYearSellerResult(sellerID, year);

        return results;
    }

    private GetSellerResultsDTO? GetDaySellerResult(int sellerID, DateOnly dateOnly)
    {
        GetSellerResultsDTO sellerResults = new GetSellerResultsDTO();

        ICollection<Result> results = (
            from result in this._context.Results
            where
                result.SellerID == sellerID
                && result.Date == dateOnly
            select result
        ).ToList();

        GetSellerResultsDTO dto = new GetSellerResultsDTO()
        {
            SellerID = sellerID,
            Results = this._mapper.Map<ICollection<GetResultDTO>>(results)
        };

        return sellerResults;
    }

    private GetSellerResultsDTO? GetMonthSellerResult(int sellerID, int year, int month)
    {
        GetSellerResultsDTO sellerResults = new GetSellerResultsDTO();

        ICollection<Result> results = (
            from result in this._context.Results
            where
                result.SellerID == sellerID
                && result.Date.Year == year
                && result.Date.Month == month
            select result
        ).ToList();

        GetSellerResultsDTO dto = new GetSellerResultsDTO()
        {
            SellerID = sellerID,
            Results = this._mapper.Map<ICollection<GetResultDTO>>(results)
        };

        return sellerResults;
    }

    private GetSellerResultsDTO? GetQuarterSellerResult(int sellerID, int year, int quarter)
    {
        GetSellerResultsDTO sellerResults = new GetSellerResultsDTO();

        ICollection<Result> results = (
            from result in this._context.Results
            where
                result.SellerID == sellerID
                && result.Date.Year == year
                && Math.Ceiling(result.Date.Month / 3.0) == quarter
            select result
        ).ToList();

        GetSellerResultsDTO dto = new GetSellerResultsDTO()
        {
            SellerID = sellerID,
            Results = this._mapper.Map<ICollection<GetResultDTO>>(results)
        };

        return sellerResults;
    }

    private GetSellerResultsDTO? GetYearSellerResult(int sellerID, int year)
    {
        GetSellerResultsDTO sellerResults = new GetSellerResultsDTO();

        ICollection<Result> results = (
            from result in this._context.Results
            where
                result.SellerID == sellerID
                && result.Date.Year == year
            select result
        ).ToList();

        GetSellerResultsDTO dto = new GetSellerResultsDTO()
        {
            SellerID = sellerID,
            Results = this._mapper.Map<ICollection<GetResultDTO>>(results)
        };

        return sellerResults;
    }

    private GetSellerResultsDTO GetAllTimeSellerResult(int sellerID)
    {
        GetSellerResultsDTO sellerResults = new GetSellerResultsDTO();

        ICollection<Result> results = (
            from result in this._context.Results
            where
                result.SellerID == sellerID
            select result
        ).ToList();

        GetSellerResultsDTO dto = new GetSellerResultsDTO()
        {
            SellerID = sellerID,
            Results = this._mapper.Map<ICollection<GetResultDTO>>(results)
        };

        return sellerResults;
    }
}