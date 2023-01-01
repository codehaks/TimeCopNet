using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCop.TimeSheet.Domain;
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
    private readonly IUoW _uoW;
    public SessionService(ISessionRepository sessionRepository, IUoW uoW)
    {
        _sessionRepository = sessionRepository;
        _uoW = uoW;
    }

    public void Create(HourInput input)
    {
        // Validate
        // Log
        // ...

        var session = _sessionRepository.Get(input.StaffId); // Read Domain
        session.AddHour(input.Note); // Update Domain
        _sessionRepository.Add(session); // Domain -> Data

        _uoW.CommitChange();

    }

    public Session Get(int staffId)
    {
        return _sessionRepository.Get(staffId);
    }
}