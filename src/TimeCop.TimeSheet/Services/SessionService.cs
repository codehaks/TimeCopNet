using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCop.TimeSheet.Domain;

namespace TimeCop.TimeSheet.Services;

public class HourInput
{
    public required string StaffName { get; set; }
    public string StaffId { get; set; }
    public LocalDateTime LogTime { get; set; }
    public string? Note { get; set; }
}

public class SessionService
{
    private readonly ISessionRepository _sessionRepository;

    public SessionService(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public void Create(HourInput input)
    {

    }
}
