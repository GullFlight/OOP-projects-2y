namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public class ArgumentIterator
{
    private readonly List<string> _arguments;
    private int _position;

    public ArgumentIterator(string arguments)
    {
        _arguments = arguments.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    public bool TryTake(string expected)
    {
        if (_position < _arguments.Count && _arguments[_position] == expected)
        {
            ++_position;
            return true;
        }

        return false;
    }

    public string? Take()
    {
        return _position < _arguments.Count ? _arguments[_position++] : null;
    }
}