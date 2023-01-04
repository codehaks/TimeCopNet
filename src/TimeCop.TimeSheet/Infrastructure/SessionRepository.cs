using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCop.TimeSheet.Data;
using TimeCop.TimeSheet.Domain.Models;

namespace TimeCop.TimeSheet.Infrastructure;

public class SessionRepository : ISessionRepository
{
    private readonly TimeSheetDbContext _db;

    public SessionRepository(TimeSheetDbContext db)
    {
        _db = db;
    }

    public void Add(Session session)
    {
        if (session.State == SessionState.InProgress && session.StartHour is not null)
        {
            _db.Hours.Add(session.StartHour.Adapt<HourData>());
        }

        if (session.State == SessionState.Done && session.StartHour is not null)
        {
            _db.Hours.Add(session.EndHour.Adapt<HourData>());
        }

        _db.SaveChanges();

    }

    public Session Get(int staffId)
    {
        var lastHours = _db.Hours.OrderByDescending(h => h.LogTime)
            .Where(h => h.StaffId == staffId.ToString()).Take(2).ToList();

        if (lastHours.Any() && lastHours.First().Status == "in")
        {
            return Session.BuildByStartHour(lastHours.First().Adapt<Hour>());
        }

        if (lastHours.Any() && lastHours.Last().Status == "out")
        {
            return Session.BuildByFullHours(lastHours.Last().Adapt<Hour>(), lastHours.First().Adapt<Hour>());
        }

        var staff = _db.Staffs.First(s => s.Id == staffId);
        var session = new Session(staffId, staff.FirstName + " " +staff.LastName);
        return session;
    }
}
