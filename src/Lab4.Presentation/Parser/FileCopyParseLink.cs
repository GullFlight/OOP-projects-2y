using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public class FileCopyParseLink : ParseLinkBase
{
    public override ICommand? Parse(ArgumentIterator iterator)
    {
        if (!iterator.TryTake("file"))
            return ParseNext(iterator);

        if (!iterator.TryTake("copy"))
            return ParseNext(iterator);

        string? sourcePath = iterator.Take();
        string? destinationPath = iterator.Take();
        if (sourcePath == null || destinationPath == null)
            return ParseNext(iterator);

        return new FileCopyCommand(sourcePath, destinationPath);
    }
}