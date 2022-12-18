using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCop.TimeSheet.Domain;

public enum SessionState
{
    Todo=0,
    InProgress=1,
    Done=2
}

public class Session
{
    private readonly string StaffId;
    private readonly string StaffName;

    public Session(string staffId, string staffName)
    {
        StaffId = staffId;
        StaffName = staffName;
    }

    public Hour? StartHour { get; private set; }
    public Hour? EndHour { get; private set; }

    public void Start(string note = "")
    {

        StartHour = new Hour
        {
            LogTime = LocalDateTime.FromDateTime(DateTime.Now),
            StaffId = StaffId,
            StaffName = StaffName,
            Status = "in"
        };
    }

    public void End(Hour hour)
    {
        if (StartHour is not null && hour.LogTime > StartHour.LogTime)
        {
            EndHour = new Hour
            {
                LogTime = LocalDateTime.FromDateTime(DateTime.Now),
                StaffId = StaffId,
                StaffName = StaffName,
                Note=StartHour.Note,
                Status = "out"
            };
        }

    }

    public Period GetLength()
    {
        return EndHour.LogTime - StartHour.LogTime;
    }
}
