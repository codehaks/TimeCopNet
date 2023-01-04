using NodaTime;
using TimeCop.TimeSheet.Domain.Models;

namespace TimeCop.TimeSheet.Application
{
    public interface ISheetRepository
    {
        Sheet GetTimeSheetByStaffId(string staffId, LocalDateTime fromDate, LocalDateTime toDate);
    }
}