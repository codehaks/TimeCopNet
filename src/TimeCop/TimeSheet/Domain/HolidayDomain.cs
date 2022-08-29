using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCop.TimeSheet.Application;

namespace TimeCop.TimeSheet.Domain;

public class HolidayDomain
{
    public HolidayDomain(DateTime date, string note, OvertimeInput overtimeInput, int id = 0)
    {
        if (date > DateTime.Today.Date.AddDays(-1))
        {
            throw new ArgumentOutOfRangeException(nameof(date), "Date must be 1 day before start");
        }
        Date = date;

        if (string.IsNullOrEmpty(Note))
        {
            throw new ArgumentOutOfRangeException(nameof(note), "Note must have value");
        }
        Note = note;

        if (overtimeInput is not null)
        {
            CanOvertime = overtimeInput.CanOvertime;
            OverTimeLimit = overtimeInput.OverTimeLimit; //min
            OverTimeRate = overtimeInput.OverTimeRate;
        }
        else
        {
            CanOvertime = false;
            OverTimeLimit = new TimeLength(5*60); //min
            OverTimeRate = 1;
        }


    }

    public int Id { get; set; }
    public DateTime Date { get; }
    public string Note { get; }

    private bool IsOneDayLeft()
    {
        return Date > DateTime.Today.Date.AddDays(-1);
    }

    public void UpdateCanOvertime(bool can)
    {
        if (IsOneDayLeft())
        {
            CanOvertime = can;
        }
    }

    public bool CanOvertime { get; set; }
    public TimeLength OverTimeLimit { get; set; }
    public int OverTimeRate { get; set; }
}
