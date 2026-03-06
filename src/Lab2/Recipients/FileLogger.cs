namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class FileLogger : ILogger
{
    public void Log(string text)
    {
        File.AppendAllText("log.txt", text + Environment.NewLine);
    }
}