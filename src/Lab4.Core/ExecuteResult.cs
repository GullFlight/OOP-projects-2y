namespace Itmo.ObjectOrientedProgramming.Lab4.Core;

public abstract record ExecuteResult
{
    private ExecuteResult() { }

    public sealed record Success() : ExecuteResult;

    public sealed record Failure(string Message) : ExecuteResult;
}