using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public class FileMoveParseLink : ParseLinkBase
{
    public override ICommand? Parse(ArgumentIterator iterator)
    {
        if (!iterator.TryTake("file"))
            return ParseNext(iterator);

        if (!iterator.TryTake("move"))
            return ParseNext(iterator);

        string? sourcePath = iterator.Take();
        string? destinationPath = iterator.Take();
        if (sourcePath == null || destinationPath == null)
            return ParseNext(iterator);

        return new FileMoveCommand(sourcePath, destinationPath);
    }
}