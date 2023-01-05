namespace TimeCop.TimeSheet.Application;


public interface IUoW
{
    ISessionRepository Sessions { get; init; }
    void CommitChanges();
}