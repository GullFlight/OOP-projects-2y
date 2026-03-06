using Itmo.ObjectOrientedProgramming.Lab2.Formatters;

using Itmo.ObjectOrientedProgramming.Lab2.UserItems;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivers;

public class FormattingArchiver : IMessageArchiver
{
    private readonly IMessageFormatter _formatter;

    public FormattingArchiver(IMessageFormatter formatter)
    {
        _formatter = formatter;
    }

    public void Archive(Message message)
    {
        _formatter.FormatTitle(message.Title);
        _formatter.FormatBody(message.Body);
    }
}