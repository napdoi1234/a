using System;
using System.Threading;

public class Publisher
{
    public delegate void inputFunc(Clock clock);
    public event inputFunc beCalled;

    public void CallEvent(Clock clock)
    {
        beCalled(clock);
    }
    public void Run()
    {
        while (true)
        {
            var time = DateTime.Now;
            var clock = new Clock(time.Hour, time.Minute, time.Second);
            CallEvent(clock);
            Thread.Sleep(1000);
        }

    }

}