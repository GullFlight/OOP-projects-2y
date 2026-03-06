namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class MarkDownFormatter : IMessageFormatter
{
    private readonly IMessageFormatter _messageFormatter;

    public MarkDownFormatter(IMessageFormatter formatter)
    {
        _messageFormatter = formatter;
    }

    public void FormatTitle(string title)
    {
        _messageFormatter.FormatTitle($"# {title}\n");
    }

    public void FormatBody(string body)
    {
        _messageFormatter.FormatTitle($"# {body}\n");
    }
}