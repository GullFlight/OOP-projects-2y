using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class CommandParser
{
    private readonly ParseLinkBase _link;

    public CommandParser(IConnectionMode connectionMode, IOutputMode outputMode)
    {
        _link = new ConnectParseLink()
            .SetNext(new DisconnectParseLink())
            .SetNext(new FileShowParseLink(connectionMode))
            .SetNext(new FileCopyParseLink())
            .SetNext(new FileRenameParseLink())
            .SetNext(new FileDeleteParseLink())
            .SetNext(new FileMoveParseLink())
            .SetNext(new TreeGotoParseLink())
            .SetNext(new TreeListParseLink());
    }

    public ICommand? Parse(string command)
    {
        var iterator = new ArgumentIterator(command);
        return _link.Parse(iterator);
    }
}