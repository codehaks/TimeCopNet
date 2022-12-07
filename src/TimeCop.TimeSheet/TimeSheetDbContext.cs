using Microsoft.EntityFrameworkCore;

namespace TimeCop.TimeSheet.Infrastructure;

public class TimeSheetDbContext : DbContext
{
    public TimeSheetDbContext(DbContextOptions<TimeSheetDbContext> options)
           : base(options)
    {
    }
  
}
