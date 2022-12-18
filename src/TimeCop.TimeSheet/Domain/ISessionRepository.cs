using TimeCop.TimeSheet.Domain.Models;

namespace TimeCop.TimeSheet.Domain
{
    public interface ISessionRepository
    {
        void AddHour(Session session);
        Session Get(int staffId);
    }
}