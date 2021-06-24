public class Clock
{
    public int Hour { get; set; }
    public int Minute { get; set; }
    public int Second { get; set; }
    public Clock(int hour, int minute, int second)
    {
        this.Hour = hour;
        this.Minute = minute;
        this.Second = second;
    }
}