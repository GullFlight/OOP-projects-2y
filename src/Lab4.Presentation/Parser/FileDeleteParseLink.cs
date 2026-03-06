using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public class FileDeleteParseLink : ParseLinkBase
{
    public override ICommand? Parse(ArgumentIterator iterator)
    {
        if (!iterator.TryTake("file"))
            return ParseNext(iterator);

        if (!iterator.TryTake("delete"))
            return ParseNext(iterator);

        string? deletePath = iterator.Take();
        if (deletePath == null)
            return ParseNext(iterator);

        return new FileDeleteCommand(deletePath);
    }
}