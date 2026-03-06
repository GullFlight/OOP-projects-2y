namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class ConsoleMessageFormatter : IMessageFormatter
{
    public void FormatTitle(string title)
    {
        Console.WriteLine(title);
    }

    public void FormatBody(string body)
    {
        Console.WriteLine(body);
    }
}