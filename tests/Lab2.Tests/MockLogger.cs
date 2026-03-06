using Itmo.ObjectOrientedProgramming.Lab2.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class MockLogger : ILogger
{
    private readonly List<string> _logmessages = new();

    public IReadOnlyList<string> Messages => _logmessages.AsReadOnly();

    public int LogMessageCalls => _logmessages.Count;

    private ILogger Logger { get; }

    public MockLogger(ILogger logger)
    {
        Logger = logger;
    }

    public void Log(string text)
    {
        _logmessages.Add(text);
        Logger.Log(text);
    }
}