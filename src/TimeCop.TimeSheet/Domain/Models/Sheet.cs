namespace TimeCop.TimeSheet.Domain.Models;

public class Sheet
{
    public required IList<Session> Sessions { get; set; }
}
