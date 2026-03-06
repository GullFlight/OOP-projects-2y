using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public class TreeListParseLink : ParseLinkBase
{
    public override ICommand? Parse(ArgumentIterator iterator)
    {
        if (!iterator.TryTake("tree"))
            return ParseNext(iterator);

        if (!iterator.TryTake("list"))
            return ParseNext(iterator);

        string? depthString = iterator.Take();
        if (iterator.TryTake("-d"))
        {
            depthString = iterator.Take() ?? "1";
        }

        int depth = int.TryParse(depthString, out int depthInt) ? depthInt : 0;
        return new TreeListCommand(depth, new ConsoleShowMode());
    }
}