using TimeCop.TimeSheet.Infrastructure.Persistence.DataModels;

namespace TimeCop.TimeSheet.Application.Services
{
    public interface IStaffService
    {
        Staff Get(int id);
        IList<Staff> GetAll();
    }
}