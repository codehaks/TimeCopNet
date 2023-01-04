using TimeCop.TimeSheet.Domain.Models;

namespace TimeCop.TimeSheet.Application.Services
{
    public interface ISessionService
    {
        void Create(HourInput input);
        Session Get(int staffId);
    }
}