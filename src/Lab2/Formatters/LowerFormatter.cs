namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class LowerFormatter : IMessageFormatter
{
    private readonly IMessageFormatter _messageFormatter;

    public LowerFormatter(IMessageFormatter formatter)
    {
        _messageFormatter = formatter;
    }

    public void FormatTitle(string title)
    {
        _messageFormatter.FormatTitle($" {title.ToLowerInvariant()}\n");
    }

    public void FormatBody(string body)
    {
        _messageFormatter.FormatTitle($" {body.ToLowerInvariant()}\n");
    }
}