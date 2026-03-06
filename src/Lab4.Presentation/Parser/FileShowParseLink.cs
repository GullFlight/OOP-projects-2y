using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public class FileShowParseLink : ParseLinkBase
{
    private readonly IConnectionMode _mode;

    public FileShowParseLink(IConnectionMode mode)
    {
        _mode = mode;
    }

    public override ICommand? Parse(ArgumentIterator iterator)
    {
        if (!iterator.TryTake("file"))
            return ParseNext(iterator);

        if (!iterator.TryTake("show"))
            return ParseNext(iterator);

        string? address = iterator.Take();
        if (address == null)
            return null;

        string mode = string.Empty;
        if (iterator.TryTake("-m"))
        {
            mode = iterator.Take() ?? "console";
        }

        return new FileShowCommand(address, _mode);
    }
}