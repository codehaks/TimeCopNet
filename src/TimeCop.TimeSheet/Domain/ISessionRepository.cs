using TimeCop.TimeSheet.Domain.Models;

namespace TimeCop.TimeSheet.Domain
{
    public interface ISessionRepository
    {
        void Add(Session session);
        Session Get(int staffId);
    }
}