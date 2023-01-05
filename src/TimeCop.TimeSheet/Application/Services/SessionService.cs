using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCop.TimeSheet.Domain.Models;

namespace TimeCop.TimeSheet.Application.Services;

public class HourInput
{
    public required string StaffName { get; set; }
    public int StaffId { get; set; }
    public string? Note { get; set; }
}

public class SessionService : ISessionService
{
    private readonly IUoW _uoW;

    public SessionService(IUoW uoW)
    {
        _uoW = uoW;
    }

    public void Create(HourInput input)
    {
        var session = _uoW.Sessions.Get(input.StaffId);

        session.AddHour(input.Note);

        _uoW.Sessions.Add(session);

        _uoW.CommitChanges();

    }

    public Session Get(int staffId)
    {
        return _uoW.Sessions.Get(staffId);
    }
}