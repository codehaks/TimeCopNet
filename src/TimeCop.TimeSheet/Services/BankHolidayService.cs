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
        ValidateCreateBankHoliday(date, name);

        _db.BankHolidays.Add(new Data.BankHoliday { Date = date, Name = name });
        await _db.SaveChangesAsync();
    }

    public static void ValidateCreateBankHoliday(LocalDate date, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name), "Name can not be null or empty");
        }

        if (date <= LocalDate.FromDateTime(DateTime.Now))
        {
            throw new ArgumentOutOfRangeException(nameof(date), "Date can not be in the past");
        }
    }

    public IList<BankHoliday> GetAll()
    {
        return _db.BankHolidays.ToList();
    }
}
