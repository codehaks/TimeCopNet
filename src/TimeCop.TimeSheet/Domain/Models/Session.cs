using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCop.TimeSheet.Domain.Models;

public enum SessionState
{
    Todo = 0,
    InProgress = 1,
    Done = 2
}

public class Session
{
    private readonly int StaffId;
    private readonly string StaffName;

    public Session(int staffId, string staffName)
    {
        StaffId = staffId;
        StaffName = staffName;
        State = SessionState.Todo;
    }

    public static Session BuildByStartHour(Hour startHour)
    {
        if (startHour.LogTime < LocalDateTime.FromDateTime(DateTime.Now.Date))
        {
            return new Session(startHour.StaffId, startHour.StaffName);
        }

        if (startHour.LogTime.Date == LocalDateTime.FromDateTime(DateTime.Now).Date)
        {
            var session= new Session(startHour.StaffId, startHour.StaffName);
            session.SetStartHour(startHour);
            return session;
        }

        throw new InvalidOperationException("Can not build session");
    }

    public static Session BuildByFullHours(Hour startHour,Hour endHour)
    {
        if (endHour.LogTime < LocalDateTime.FromDateTime(DateTime.Now.Date))
        {
            return new Session(startHour.StaffId, startHour.StaffName);
        }

        if (endHour.LogTime.Date == LocalDateTime.FromDateTime(DateTime.Now).Date)
        {
            var session = new Session(startHour.StaffId, startHour.StaffName);
            session.SetStartHour(startHour);
            session.SetEndHour(endHour);
            return session;
        }


        throw new InvalidOperationException("Can not build session");
    }

    private void SetStartHour(Hour hour)
    {
        StartHour = hour;
        State = SessionState.InProgress;
    }

    private void SetEndHour(Hour hour)
    {
        EndHour = hour;
        State = SessionState.Done;
    }

    public Hour? StartHour { get; private set; }
    public Hour? EndHour { get; private set; }

    public SessionState State { get; private set; }

    public void Start(string note = "")
    {

        StartHour = new Hour
        {
            LogTime = LocalDateTime.FromDateTime(DateTime.Now),
            StaffId = StaffId,
            StaffName = StaffName,
            Status = "in"
        };

        State = SessionState.InProgress;
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
                Note = StartHour.Note,
                Status = "out"
            };
        }

        State = SessionState.Done;

    }

    public Period GetLength()
    {
        return EndHour.LogTime - StartHour.LogTime;
    }
}
