namespace IDETimer;

public class TimeData
{
    public TimeSpan WorkingTime { get; set; }
    public TimeSpan WasteOfTime { get; set; }

    public TimeData()
    {
        WorkingTime = TimeSpan.Zero;
        WasteOfTime = TimeSpan.Zero;
    }
}