using Itmo.ObjectOrientedProgramming.Lab2.Formatters;
using Microsoft.VisualBasic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class MockFormatter : IMessageFormatter
{
    public Collection Messages { get; } = new();

    public int FormatTitleCalls { get; private set; }

    public int FormatBodyCalls { get; private set; }

    public MockFormatter()
    {
        FormatTitleCalls = 0;
        FormatBodyCalls = 0;
    }

    public void FormatTitle(string title)
    {
        FormatTitleCalls++;
        Messages.Add($"# {title}\n");
    }

    public void FormatBody(string body)
    {
        FormatBodyCalls++;
        Messages.Add($"# {body}\n");
    }
}