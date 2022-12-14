using NodaTime;
using TimeCop.TimeSheet.Data;

namespace TimeCop.TimeSheet.Services;

public interface IBankHolidayService
{    
    Task Create(LocalDate date, string name);
    IList<BankHoliday> GetAll();
}