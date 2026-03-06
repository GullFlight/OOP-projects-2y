using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public interface IParseLink
{
    ICommand? Parse(ArgumentIterator iterator);
}
