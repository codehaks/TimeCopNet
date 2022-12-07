using Microsoft.EntityFrameworkCore;
using TimeCop.TimeSheet.Data;

namespace TimeCop.TimeSheet.Infrastructure;

public class TimeSheetDbContext : DbContext
{
    public TimeSheetDbContext(DbContextOptions<TimeSheetDbContext> options)
           : base(options)
    {
    }

    public DbSet<BankHoliday> BankHolidays { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<BankHoliday>().Property(p=>p.Name).HasMaxLength(50).IsRequired();
        builder.Entity<BankHoliday>().Property(p => p.Date).IsRequired();

        base.OnModelCreating(builder);
    }

}
