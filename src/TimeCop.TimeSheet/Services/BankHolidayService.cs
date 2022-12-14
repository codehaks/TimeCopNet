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
        _db.BankHolidays.Add(new Data.BankHoliday { Date = date, Name = name });
        await _db.SaveChangesAsync();
    }

    public IList<BankHoliday> GetAll()
    {
        return _db.BankHolidays.ToList();
    }
}
