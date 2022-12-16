using TimeCop.TimeSheet.Data;

namespace TimeCop.TimeSheet.Services
{
    public interface IStaffService
    {
        Staff Get(int id);
        IList<Staff> GetAll();
    }
}