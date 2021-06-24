using System;
public class Subcriber
{
    public void Subcribe(Publisher publisher)
    {
        publisher.beCalled += Print;
    }
    public void Print(Clock clock)
    {
        Console.WriteLine($"Now is {clock.Hour}: hour {clock.Minute}: Minute {clock.Second}: second");
    }
}