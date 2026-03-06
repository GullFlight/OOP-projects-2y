namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract record ApplyForceResult
{
    private ApplyForceResult() { }

    public sealed record Success() : ApplyForceResult;

    public sealed record Failure() : ApplyForceResult;
}