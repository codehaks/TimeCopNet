using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCop.TimeSheet.Data;
using TimeCop.TimeSheet.Infrastructure;

namespace TimeCop.TimeSheet.Services;

public class BankHolidayService : IBankHolidayService
{
    private readonly TimeSheetDbContext _db;

    public BankHolidayService(TimeSheetDbContext db)
    {
        _db = db;
    }


    public async Task Create(LocalDate date, string name)
    {
        // Pre-conditions
        Guard.Against.NullOrEmpty(name, nameof(name), "Name can not be null or empty");
        Guard.Against.OutOfRange(date, nameof(date), rangeFrom: LocalDate.FromDateTime(DateTime.Now), LocalDate.FromDateTime(DateTime.Now.AddYears(100)), message: "Date can not be in the past");

        // Happy path
        _db.BankHolidays.Add(new Data.BankHoliday { Date = date, Name = name });
        await _db.SaveChangesAsync();
    }

    public IList<BankHoliday> GetAll()
    {
        return _db.BankHolidays.ToList();
    }
}
