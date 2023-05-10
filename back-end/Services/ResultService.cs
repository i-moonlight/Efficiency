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
                .Take(take == 0 ? this._context.Results.Count() : take)
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
        ResultDTO.Date = DateOnly.FromDateTime(ResultDTO.DateTime);

        GetResultDTO? dto = null;
        Result? Result = _context.Results?.FirstOrDefault(
            result =>
                result.Date.CompareTo(ResultDTO.Date) == 0
                && result.SellerID == ResultDTO.SellerID
        );

        // if Result is null, it means that no result 
        // with the informed date and seller
        // was found, meaning we can add it to the 
        // database with no duplicates
        if (Result == null)
        {
            Result = _mapper.Map<Result>(ResultDTO);
            _context.Results?.Add(Result);
            _context.SaveChanges();
            // POST Result -> POST Service -> POST ServicesResults
            dto = _mapper.Map<GetResultDTO>(Result);
        }

        return dto;
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

    public ICollection<GetSellerResultsDTO>? GetSellerResults(
        int sellerID,
        int year,
        Quarter? quarter,
        Month? month,
        int day
    )
    {
        ICollection<int> seller = new List<int>(sellerID);
        ICollection<GetSellerResultsDTO>? results = null;

        if (year == 0 || year > DateTime.Now.Year)
            results = this.GetBulkAllTimeSellerResults(seller);
        else if (quarter != null)
            results = this.GetBulkQuarterSellerResults(seller, year, (int)quarter);
        else if (month != null)
            if (day > 0 && day <= 31)
                results = this.GetBulkDaySellerResults(
                        seller,
                        DateOnly.FromDateTime(new DateTime(year, ((int)month), day))
                    );
            else
                results = this.GetBulkMonthSellerResults(seller, year, ((int)month));
        else
            results = this.GetBulkYearSellerResults(seller, year);

        return results;
    }

    public ICollection<GetSellerResultsDTO>? GetBulkSellersResults(
        ICollection<int> sellersIDs,
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
                results = this.GetBulkAllTimeSellerResults(sellersIDs);
            else if (quarter != null)
                results = this.GetBulkQuarterSellerResults(sellersIDs, year, (int)quarter);
            else if (month != null)
                if (day > 0 && day < 31)
                    results = this.GetBulkDaySellerResults(
                            sellersIDs,
                            DateOnly.FromDateTime(new DateTime(year, ((int)month), day))
                        );
                else
                    results = this.GetBulkMonthSellerResults(sellersIDs, year, ((int)month));
            else
                results = this.GetBulkYearSellerResults(sellersIDs, year);
        }

        return results;
    }

    private ICollection<GetSellerResultsDTO>? GetBulkDaySellerResults(
        ICollection<int> sellersIDs,
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

            if (results.Count > 0)
            {
                GetSellerResultsDTO dto = new GetSellerResultsDTO()
                {
                    SellerID = sellerID,
                    Results = this._mapper.Map<ICollection<GetResultDTO>>(results)
                };

                sellersResults.Add(dto);
            }
        }

        return sellersResults.Count > 0 ? sellersResults : null;
    }

    private ICollection<GetSellerResultsDTO>? GetBulkMonthSellerResults(
        ICollection<int> sellersIDs,
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

            if (results.Count > 0)
            {
                GetSellerResultsDTO dto = new GetSellerResultsDTO()
                {
                    SellerID = sellerID,
                    Results = this._mapper.Map<ICollection<GetResultDTO>>(results)
                };

                sellersResults.Add(dto);
            }
        }

        return sellersResults.Count > 0 ? sellersResults : null;
    }

    private ICollection<GetSellerResultsDTO>? GetBulkQuarterSellerResults(
        ICollection<int> sellersIDs,
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

            if (results.Count > 0)
            {
                GetSellerResultsDTO dto = new GetSellerResultsDTO()
                {
                    SellerID = sellerID,
                    Results = this._mapper.Map<ICollection<GetResultDTO>>(results)
                };

                sellersResults.Add(dto);
            }
        }

        return sellersResults.Count > 0 ? sellersResults : null;
    }

    private ICollection<GetSellerResultsDTO>? GetBulkYearSellerResults(
        ICollection<int> sellersIDs,
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

            if (results.Count > 0)
            {
                GetSellerResultsDTO dto = new GetSellerResultsDTO()
                {
                    SellerID = sellerID,
                    Results = this._mapper.Map<ICollection<GetResultDTO>>(results)
                };

                sellersResults.Add(dto);
            }
        }

        return sellersResults.Count > 0 ? sellersResults : null;
    }

    private ICollection<GetSellerResultsDTO>? GetBulkAllTimeSellerResults(ICollection<int> sellersIDs)
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

            if (results.Count > 0)
            {
                GetSellerResultsDTO dto = new GetSellerResultsDTO()
                {
                    SellerID = sellerID,
                    Results = this._mapper.Map<ICollection<GetResultDTO>>(results)
                };

                sellersResults.Add(dto);
            }
        }

        return sellersResults.Count > 0 ? sellersResults : null;
    }
}