namespace TimeCop.TimeSheet.Domain;

public class TimeLength
{
	public TimeLength(int value)
	{
		if (value<0)
		{
			throw new ArgumentOutOfRangeException(nameof(value), "Time can not be less than 0");
		}
		Value = value; 
		
	}
    public int Value { get; init; }

	public double GetHours()
	{
		return Math.Round(Convert.ToSingle(Value) / 60,2);
	}
}
