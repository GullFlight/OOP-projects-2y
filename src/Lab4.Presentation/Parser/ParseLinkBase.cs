using ICommand = Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ICommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public abstract class ParseLinkBase : IParseLink
{
    private IParseLink? _next;

    public ParseLinkBase SetNext(ParseLinkBase next)
    {
        _next = next;
        return next;
    }

    public IParseLink AddNext(IParseLink link)
    {
        if (_next is null)
        {
            _next = link;
        }

        return this;
    }

    public abstract ICommand? Parse(ArgumentIterator iterator);

    protected ICommand? ParseNext(ArgumentIterator iterator)
    {
        return _next?.Parse(iterator);
    }
}