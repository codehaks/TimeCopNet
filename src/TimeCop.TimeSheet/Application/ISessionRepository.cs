using TimeCop.TimeSheet.Domain.Models;

namespace TimeCop.TimeSheet.Application
{
    public interface ISessionRepository
    {
        void Add(Session session);
        Session Get(int staffId);
    }
}