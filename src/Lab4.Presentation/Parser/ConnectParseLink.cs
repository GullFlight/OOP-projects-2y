using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public class ConnectParseLink : ParseLinkBase
{
    public override ICommand? Parse(ArgumentIterator iterator)
    {
        if (!iterator.TryTake("connect"))
            return ParseNext(iterator);

        string? address = iterator.Take();
        if (address == null)
            return null;

        string mode = string.Empty;
        if (iterator.TryTake("-m"))
        {
            mode = iterator.Take() ?? "local";
        }

        return new ConnectCommand(address, mode);
    }
}