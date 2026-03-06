namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract record RouteResult
{
    private RouteResult() { }

    public sealed record Success() : RouteResult;

    public sealed record Failure() : RouteResult;
}
