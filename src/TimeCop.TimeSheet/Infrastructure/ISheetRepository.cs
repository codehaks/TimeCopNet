using NodaTime;
using TimeCop.TimeSheet.Domain.Models;

namespace TimeCop.TimeSheet.Infrastructure
{
    public interface ISheetRepository
    {
        Sheet GetTimeSheetByStaffId(string staffId, LocalDateTime fromDate, LocalDateTime toDate);
    }
}