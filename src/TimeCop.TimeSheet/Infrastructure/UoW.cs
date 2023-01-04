using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCop.TimeSheet.Infrastructure.Persistence;

namespace TimeCop.TimeSheet.Infrastructure;

public class UoW : IUoW
{
    private readonly TimeSheetDbContext _db;

    public UoW(TimeSheetDbContext db)
    {
        _db = db;
    }

    public void CommitChanges()
    {
        _db.SaveChanges();
    }
}
