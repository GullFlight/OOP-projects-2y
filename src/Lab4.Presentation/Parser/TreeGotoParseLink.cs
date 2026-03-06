using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public class TreeGotoParseLink : ParseLinkBase
{
    public override ICommand? Parse(ArgumentIterator iterator)
    {
        if (!iterator.TryTake("tree"))
            return ParseNext(iterator);

        if (!iterator.TryTake("goto"))
            return ParseNext(iterator);

        string? path = iterator.Take();
        if (path == null)
            return ParseNext(iterator);

        return new TreeGotoCommand(path);
    }
}