using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        await _repository.AddHoliday(holiday);

    }

    public Task<Holiday> GetAsync(int holidayId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateOvertime(OvertimeInput input)
    {
        await _repository.UpdateOvertime(input);
    }
}
