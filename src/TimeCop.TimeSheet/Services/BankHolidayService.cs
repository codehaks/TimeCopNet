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
        // Pre-Conditions
        var nameHasValue = string.IsNullOrEmpty(name) == false;
        var dateIsInFuture = date >= new LocalDate();


        if ((dateIsInFuture && nameHasValue) == false)
        {
            throw new ArgumentOutOfRangeException("Date or Name is not valid.");
        }

        try
        {
            // Happy Path
            _db.BankHolidays.Add(new Data.BankHoliday { Date = date, Name = name });
            var stateEnteries = await _db.SaveChangesAsync();

            // Post-Condition
            if (stateEnteries <= 0)
            {
                throw new InvalidOperationException("Could not store new Bank Holiday.");
            }
        }
        catch (DbUpdateException dbEx)
        {

            throw dbEx;
        }





    }

    public IList<BankHoliday> GetAll()
    {
        return _db.BankHolidays.ToList();
    }
}
