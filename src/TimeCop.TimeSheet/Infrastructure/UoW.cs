namespace TimeCop.TimeSheet.Infrastructure;

public class UoW : IUoW
{
    private readonly TimeSheetDbContext _db;

    public UoW(TimeSheetDbContext db)
    {
        _db = db;
    }

    public void CommitChange()
    {
        _db.SaveChanges();
    }
}
