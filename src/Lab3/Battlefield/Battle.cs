using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Battlefield;

public class Battle
{
    private readonly PlayerTable _firstPlayerTable;
    private readonly PlayerTable _secondPlayerTable;

    public Battle(PlayerTable firstPlayerTable, PlayerTable secondPlayerTable)
    {
        _firstPlayerTable = firstPlayerTable.Clone();
        _secondPlayerTable = secondPlayerTable.Clone();
    }

    public BattleResult Game()
    {
        while (true)
        {
            BattleResult? firstAttack = PlayerTurn(_firstPlayerTable, _secondPlayerTable);
            if (firstAttack is not null)
                return firstAttack;
            BattleResult? secondAttack = PlayerTurn(_secondPlayerTable, _firstPlayerTable);
            if (secondAttack is not null)
                return secondAttack;
        }
    }

    private BattleResult? PlayerTurn(PlayerTable attackingPlayer, PlayerTable defendingPlayer)
    {
        ICreature? attacker = attackingPlayer.GetRandomAttackingCreature();

        ICreature? defender = defendingPlayer.GetRandomTargetCreature();

        if (attacker is not null && defender is null)
        {
            return attackingPlayer == _firstPlayerTable
                ? new BattleResult.FirstPlayerWin()
                : new BattleResult.SecondPlayerWin();
        }

        if (attacker is null && defender is null)
            return new BattleResult.Draw();

        if (defender is not null && attacker is not null)
            attacker.Attacking(defender);
        return null;
    }
}