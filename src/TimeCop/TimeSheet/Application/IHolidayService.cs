using TimeCop.TimeSheet.Models;

namespace TimeCop.TimeSheet.Application
{
    public interface IHolidayService
    {
        Task Add(Holiday holiday);
        Task<IList<HolidayReadData>> GetAll();
        Task<Holiday> GetAsync(int holidayId);
        Task UpdateOvertime(OvertimeInput input);
    }
}