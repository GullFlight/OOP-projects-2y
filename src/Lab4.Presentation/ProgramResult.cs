namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public record ProgramResult
{
    private ProgramResult() { }

    public sealed record Success() : ProgramResult;

    public sealed record Failure(string Message) : ProgramResult;
}
