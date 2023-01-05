﻿using Microsoft.EntityFrameworkCore;
using TimeCop.TimeSheet.Infrastructure.Persistence.DataModels;

namespace TimeCop.TimeSheet.Infrastructure.Persistence;

public class TimeSheetDbContext : DbContext
{
    public TimeSheetDbContext(DbContextOptions<TimeSheetDbContext> options)
           : base(options)
    {
    }

    public DbSet<BankHoliday> BankHolidays { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<HourData> Hours { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<BankHoliday>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        builder.Entity<BankHoliday>().Property(p => p.Date).IsRequired();

        base.OnModelCreating(builder);
    }

}