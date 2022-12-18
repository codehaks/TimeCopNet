using TimeCop.TimeSheet.Domain.Models;

namespace TimeCop.TimeSheet.Services
{
    public interface ISessionService
    {
        void Create(HourInput input);
        Session Get(int staffId);
    }
}