using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCop.TimeSheet.Domain;

public class Session
{
    private readonly string StaffId;
    private readonly string StaffName;

    public Session(string staffId, string staffName)
    {
        StaffId = staffId;
        StaffName = staffName;
    }

    public Hour StartHour { get; private set; }
    public Hour EndHour { get; private set; }

    public void Start(string note = "")
    {
        //StartHour = new Hour
        //{
        //    LogTime = LocalDate.FromDateTime(DateTime.Now),
        //    StaffId=StaffId,
        //    StaffName=StaffName,
        //    Status="in"
        //}
    }

    public void End(Hour hour)
    {
        if (hour.LogTime > StartHour.LogTime)
        {
            EndHour = hour;
        }

    }

    public Period GetLength()
    {
        return EndHour.LogTime - StartHour.LogTime;
    }
}
