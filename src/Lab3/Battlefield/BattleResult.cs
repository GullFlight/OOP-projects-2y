namespace Itmo.ObjectOrientedProgramming.Lab3.Battlefield;

public abstract record BattleResult
{
    private BattleResult() { }

    public sealed record Draw() : BattleResult;

    public sealed record FirstPlayerWin() : BattleResult;

    public sealed record SecondPlayerWin() : BattleResult;
}