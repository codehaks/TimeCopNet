using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCop.TimeSheet.Data;
using TimeCop.TimeSheet.Domain;
using TimeCop.TimeSheet.Domain.Models;

namespace TimeCop.TimeSheet.Infrastructure;

public class SessionRepository : ISessionRepository
{
    private readonly TimeSheetDbContext _db;

    public SessionRepository(TimeSheetDbContext db)
    {
        _db = db;
    }

    public void AddHour(Session session)
    {
        if (session.State == SessionState.InProgress && session.StartHour is not null)
        {
            _db.Hours.Add(session.StartHour.Adapt<HourData>());
        }

        if (session.State == SessionState.Done && session.StartHour is not null)
        {
            _db.Hours.Add(session.StartHour.Adapt<HourData>());
        }

        _db.SaveChanges();

    }


}
