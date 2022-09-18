using TimeCop.TimeSheet.Models;

namespace TimeCop.TimeSheet.Application;

public interface IHolidayRepository
{
    Task AddHoliday(Holiday holiday);

    Task<Holiday> Find(int id);
    Task<IList<Holiday>> GetAll();
    Task UpdateOvertime(OvertimeInput input);
}