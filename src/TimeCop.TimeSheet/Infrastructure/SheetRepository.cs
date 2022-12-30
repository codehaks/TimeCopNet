using Mapster;
using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCop.TimeSheet.Domain.Models;

namespace TimeCop.TimeSheet.Infrastructure;

public class SheetRepository : ISheetRepository
{
    private readonly TimeSheetDbContext _db;

    public SheetRepository(TimeSheetDbContext db)
    {
        _db = db;
    }

    public Sheet GetTimeSheetByStaffId(string staffId, LocalDateTime fromDate, LocalDateTime toDate)
    {
        //LocalDateTime.FromDateTime(fromDate);
        var hours = _db.Hours.Where(h => h.StaffId == staffId && h.LogTime >= fromDate)
            .OrderBy(h => h.LogTime)
            .ToList();

        var sessions = new List<Session>();

        for (int i = 0; i < hours.Count - 1; i += 2)
        {
            var s = Session.BuildByFullHours(hours[i].Adapt<Hour>(), hours[i + 1].Adapt<Hour>());
            sessions.Add(s);
        }



        var sheet = new Sheet { Sessions = sessions };

        return sheet;
    }
}
