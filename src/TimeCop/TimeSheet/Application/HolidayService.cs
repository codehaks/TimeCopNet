using Mapster;
using Microsoft.AspNetCore.Mvc.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCop.TimeSheet.Domain;
using TimeCop.TimeSheet.Infrastructure;
using TimeCop.TimeSheet.Models;

namespace TimeCop.TimeSheet.Application;

public class OvertimeInput
{
    public int Id { get; set; }
    public bool CanOvertime { get; set; }
    public int OverTimeLimit { get; set; }
    public int OverTimeRate { get; set; }
}

public class HolidayService
{
    private readonly IHolidayRepository _repository;

    public HolidayService(IHolidayRepository repository)
    {
        _repository = repository;
    }

    public async Task Add(Holiday holiday)
    {
        var domain = new HolidayDomain(holiday.Date, holiday.Note,null);
        var dataModel=domain.Adapt<Holiday>();
        //---
        await _repository.AddHoliday(dataModel);

    }

    public Task<Holiday> GetAsync(int holidayId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateOvertime(OvertimeInput input)
    {
        var holidayData = await _repository.Find(input.Id);

        var domain = new HolidayDomain(holidayData.Date, holidayData.Note,input);
        domain.UpdateCanOvertime(input.CanOvertime);

        var dataModel = domain.Adapt<OvertimeInput>();
        await _repository.UpdateOvertime(dataModel);
    }
}
