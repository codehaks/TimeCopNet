using NodaTime;
using TimeCop.TimeSheet.Data;

namespace TimeCop.TimeSheet.Services;

public interface IBankHolidayService
{    
    Task Create(BankHolidayInput input);
    IList<BankHoliday> GetAll();
}

public class BankHolidayInput
{
    public LocalDate Date { get; set; }
    public required string Name { get; set; }
}