using NodaTime;
using TimeCop.Shared;
using TimeCop.TimeSheet.Infrastructure.Persistence.DataModels;

namespace TimeCop.TimeSheet.Application.Services;

public interface IBankHolidayService
{
    Task<OperationResult<bool>> Create(BankHolidayInput input);
    IList<BankHoliday> GetAll();
}

public class BankHolidayInput
{
    public LocalDate Date { get; set; }
    public required string Name { get; set; }
}