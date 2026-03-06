namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class ConsoleLogger : ILogger
{
    public void Log(string text)
    {
        Console.WriteLine($" Received: {text}");
    }
}