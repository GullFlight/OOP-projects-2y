namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract record MoveResult
{
    private MoveResult() { }

    public sealed record Success(Time Time) : MoveResult;

    public sealed record Failure() : MoveResult;
}