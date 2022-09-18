using TimeCop.Shared;

namespace TimeCop.TimeSheet.Domain;

public class TimeLength : ValueObject
{
    public TimeLength(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Time can not be less than 0");
        }
        Value = value;

    }
    public int Value { get; init; }

    public double GetHours()
    {
        return Math.Round(Convert.ToSingle(Value) / 60, 2);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    public static TimeLength operator +(TimeLength t1, TimeLength t2)
    {
        return new TimeLength(t1.Value + t2.Value);
    }

    public static TimeLength operator -(TimeLength t1, TimeLength t2)
    {
        return new TimeLength(Math.Abs(t1.Value - t2.Value));
    }
}
