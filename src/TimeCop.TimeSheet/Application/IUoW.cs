namespace TimeCop.TimeSheet.Application
{
    public interface IUoW
    {
        void CommitChanges();
    }
}