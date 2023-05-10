using AutoMapper;
using Efficiency.Data.DTO.Goal;
using Efficiency.Models;
using Efficiency.Models.Enums;

namespace Efficiency.Services;

public class GoalService
{
    private AppDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public GoalService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<GetGoalDTO> GetAll(int skip, int take)
    {
        return _mapper.Map<ICollection<GetGoalDTO>>(
            _context.Goals?
                .OrderBy(goal => goal.Year)
                .Skip(skip)
                .Take(take == 0 ? this._context.Goals.Count() : take)
                .ToList()
        );
    }

    public GetGoalDTO? Get(int ID)
    {
        return _mapper.Map<GetGoalDTO>(
            _context.Goals?.FirstOrDefault(
                Goal => Goal.ID == ID
            )
        );
    }

    public GetGoalDTO? Post(PostGoalDTO GoalDTO)
    {
        GetGoalDTO? result = null;
        Goal? Goal = _context.Goals?.FirstOrDefault(
            Goal =>
                Goal.Month == GoalDTO.Month
                && Goal.Year == GoalDTO.Year
                && Goal.StoreID == GoalDTO.StoreID
        );

        if (Goal == null)
        {
            Goal = _mapper.Map<Goal>(GoalDTO);
            _context.Goals?.Add(Goal);
            _context.SaveChanges();
            result = _mapper.Map<GetGoalDTO>(Goal);
        }

        return result;
    }

    public bool Put(PutGoalDTO GoalDTO)
    {
        bool result = false;

        Goal? Goal = _context.Goals?.FirstOrDefault(
            Goal => Goal.ID == GoalDTO.ID
        );

        if (Goal != null)
        {
            _mapper.Map(GoalDTO, Goal);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    public bool Delete(int ID)
    {
        bool result = false;

        Goal? Goal = _context.Goals?.FirstOrDefault(
            Goal => Goal.ID == ID
        );

        if (Goal != null)
        {
            _context.Remove(Goal);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }

    public ICollection<GetGoalDTO>? GetAllStoreGoals(int storeID)
    {
        return this._mapper.Map<ICollection<GetGoalDTO>>
        (
            from goal in this._context.Goals
            orderby goal.Year, goal.Month
            where goal.StoreID == storeID
            select goal
        );
    }

    public ICollection<GetGoalDTO>? GetYearStoreGoals(int storeID, int year)
    {
        return this._mapper.Map<ICollection<GetGoalDTO>>
        (
            from goal in this._context.Goals
            where goal.Year == year && goal.ID == storeID
            orderby goal.Year, goal.Month
            select goal
        );
    }

    public ICollection<GetGoalDTO>? GetQuarterStoreGoals(int storeID, int year, int quarter)
    {
        return this._mapper.Map<ICollection<GetGoalDTO>>
        (
            from goal in this._context.Goals
            where
                goal.ID == storeID &&
                goal.Year == year &&
                quarter == Math.Ceiling(((int)goal.Month) / 3.0)
            orderby goal.Year, goal.Month
            select goal
        );
    }

    public ICollection<GetGoalDTO>? GetMonthStoreGoals(int storeID, int year, Month month)
    {
        return this._mapper.Map<ICollection<GetGoalDTO>>
        (
            from goal in this._context.Goals
            where
                goal.ID == storeID &&
                goal.Year == year &&
                goal.Month == month
            orderby goal.Year, goal.Month
            select goal
        );
    }
}