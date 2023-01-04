using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCop.TimeSheet.Application;
using TimeCop.TimeSheet.Infrastructure.Persistence;
using TimeCop.TimeSheet.Infrastructure.Repository;

namespace TimeCop.TimeSheet.Infrastructure;

public class UoW : IUoW
{
    private readonly TimeSheetDbContext _db;
    private readonly ISessionRepository _sessionRepository;

    public UoW(TimeSheetDbContext db)
    {
        _db = db;
        _sessionRepository = new SessionRepository(db);
    }

    public void CommitChanges()
    {
        _db.SaveChanges();
    }
}
