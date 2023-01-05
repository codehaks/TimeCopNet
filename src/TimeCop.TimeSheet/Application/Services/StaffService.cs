﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCop.TimeSheet.Infrastructure.Persistence;
using TimeCop.TimeSheet.Infrastructure.Persistence.DataModels;

namespace TimeCop.TimeSheet.Application.Services;

public class StaffService : IStaffService
{
    private readonly TimeSheetDbContext _db;

    public StaffService(TimeSheetDbContext db)
    {
        _db = db;
    }

    public IList<Staff> GetAll()
    {
        return _db.Staffs.OrderByDescending(s => s.IsActive).ToList();
    }

    public Staff Get(int id)
    {
        return _db.Staffs.Single(s => s.Id == id);
    }
}