using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public class FileRenameParseLink : ParseLinkBase
{
    public override ICommand? Parse(ArgumentIterator iterator)
    {
        if (!iterator.TryTake("file"))
            return ParseNext(iterator);

        if (!iterator.TryTake("rename"))
            return ParseNext(iterator);

        string? path = iterator.Take();
        string? name = iterator.Take();
        if (path == null || name == null)
            return ParseNext(iterator);

        return new FileRenameCommand(path, name);
    }
}