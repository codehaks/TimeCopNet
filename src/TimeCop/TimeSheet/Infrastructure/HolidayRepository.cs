using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCop.TimeSheet.Application;
using TimeCop.TimeSheet.Models;

namespace TimeCop.TimeSheet.Infrastructure;

public class HolidayRepository : IHolidayRepository
{
    private readonly TimeSheetDbContext _db;

    public HolidayRepository(TimeSheetDbContext db)
    {
        _db = db;
    }

    public async Task AddHoliday(Holiday holiday)
    {
        _db.Holidays.Add(holiday);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateOvertime(OvertimeInput input)
    {
        var holiday = _db.Holidays.Find(input.Id);

        // validate

        holiday.CanOvertime=input.CanOvertime;
        holiday.OverTimeLimit = input.OverTimeLimit;
        holiday.OverTimeRate=input.OverTimeRate;

        await _db.SaveChangesAsync();
    }
}
