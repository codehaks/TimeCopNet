using Microsoft.EntityFrameworkCore;
using TimeCop.TimeSheet.Models;

namespace TimeCop.TimeSheet.Infrastructure;

public class TimeSheetDbContext : DbContext
{
    public TimeSheetDbContext(DbContextOptions<TimeSheetDbContext> options)
           : base(options)
    {
    }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Holiday> Holidays { get; set; }
}
