namespace Itmo.ObjectOrientedProgramming.Lab4.Core;

public abstract record UnixPathResult
{
    private UnixPathResult() { }

    public sealed record Success() : UnixPathResult;

    public sealed record Failure(string Message) : UnixPathResult;
}