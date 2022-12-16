using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCop.TimeSheet.Domain;
using TimeCop.TimeSheet.Infrastructure;

namespace TimeCop.TimeSheet.Repositories;

public class IssueRepository
{
    private readonly TimeSheetDbContext _db;

    public IssueRepository(TimeSheetDbContext db)
    {
        _db = db;
    }

    //public void Create(Sheet issue)
    //{

    //}
}
