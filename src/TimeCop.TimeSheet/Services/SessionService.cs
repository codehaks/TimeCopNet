using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCop.TimeSheet.Domain.Models;
using TimeCop.TimeSheet.Infrastructure;

namespace TimeCop.TimeSheet.Services;

public class HourInput
{
    public required string StaffName { get; set; }
    public int StaffId { get; set; }
    public string? Note { get; set; }
}

public class SessionService : ISessionService
{
    private readonly ISessionRepository _sessionRepository;

    public SessionService(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public void Create(HourInput input)
    {
        var session = _sessionRepository.Get(input.StaffId);

        session.AddHour(input.Note);
        _sessionRepository.Add(session);

    }

    public Session Get(int staffId)
    {
        return _sessionRepository.Get(staffId);
    }
}