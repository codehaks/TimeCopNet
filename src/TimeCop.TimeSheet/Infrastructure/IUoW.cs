namespace TimeCop.TimeSheet.Infrastructure
{
    public interface IUoW
    {
        void CommitChanges();
    }
}