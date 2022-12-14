using NodaTime;
using TimeCop.TimeSheet.Data;

namespace TimeCop.TimeSheet.Services
{
    public interface IBankHolidayService
    {
        void ValidateCreateBankHoliday(LocalDate date, string name);
        Task Create(LocalDate date, string name);
        IList<BankHoliday> GetAll();
    }
}