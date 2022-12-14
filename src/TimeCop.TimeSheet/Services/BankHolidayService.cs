using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TimeCop.TimeSheet.Data;
using TimeCop.TimeSheet.Domain;
using TimeCop.TimeSheet.Infrastructure;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TimeCop.TimeSheet.Services;

public class BankHolidayService : IBankHolidayService
{
    private readonly TimeSheetDbContext _db;

    public BankHolidayService(TimeSheetDbContext db)
    {
        _db = db;
    }


    public async Task Create(BankHolidayInput input)
    {
        var domain = new BankHolidayDomain { Date= input.Date, Name= input.Name};
        if (domain.IsValid()==false)
        {
            // log
            //domain.BrokenRules;
        } 
     

        // Precondition
        Guard.Against.NullOrEmpty(input.Name, nameof(input.Name), "Name can not be null or empty");
        Guard.Against.OutOfRange(input.Date, nameof(input.Date), rangeFrom: LocalDate.FromDateTime(DateTime.Now), LocalDate.FromDateTime(DateTime.Now.AddYears(100)), message: "Date can not be in the past");

        // Happy path
        _db.BankHolidays.Add(new Data.BankHoliday { Date = domain.Date, Name = domain.Name });
        await _db.SaveChangesAsync();
    }

    public IList<BankHoliday> GetAll()
    {
        return _db.BankHolidays.ToList();
    }
}
