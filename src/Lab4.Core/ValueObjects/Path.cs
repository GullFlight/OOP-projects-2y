namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;

public record Path
{
    public Path(string? path) // nullable????
    {
        if (path == null || path.StartsWith('/'))
            throw new ArgumentException("Path cannot be null");

        Value = path;
    }

    public string Value { get; }
}