using Itmo.ObjectOrientedProgramming.Lab3.Battlefield;

using Itmo.ObjectOrientedProgramming.Lab3.Builders;

using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class BattleTests
{
    [Fact]
    public void Battle_ShouldWinFirstPlayer_WhenSecondTableIsEmpty()
    {
        // Arrange
        PlayerTable table1 = PlayerTable.TableBuilder.Builder
            .AddCreature(new ImmortalHorrorBuilder()
                .WithBaseStats(new Health(4), new Attack(4))
                .Build())
            .Build();

        PlayerTable table2 = PlayerTable.TableBuilder.Builder.Build();

        // Act
        var battle = new Battle(table1, table2);

        BattleResult result = battle.Game();

        // Assert
        Assert.IsType<BattleResult.FirstPlayerWin>(result);
    }

    [Fact]
    public void Battle_ShouldGameIsOver_WhenTwoTablesAreNotEmpty()
    {
        // Arrange
        PlayerTable table1 = PlayerTable.TableBuilder.Builder
            .AddCreature(new ImmortalHorrorBuilder()
                .WithBaseStats(new Health(4), new Attack(4))
                .Build())
            .AddCreature(new AngryFighterBuilder().WithBaseStats(new Health(6), new Attack(1))
                .Build())
            .Build();

        PlayerTable table2 = PlayerTable.TableBuilder.Builder
            .AddCreature(new WarAnalystBuilder().WithBaseStats(new Health(4), new Attack(2)).Build())
            .AddCreature(new MimicChestBuilder().WithBaseStats(new Health(1), new Attack(1)).Build())
            .Build();

        // Act
        var battle = new Battle(table1, table2);

        BattleResult result = battle.Game();

        // Assert
        Assert.True(result is BattleResult.FirstPlayerWin
            or BattleResult.SecondPlayerWin
            or BattleResult.Draw);
    }

    [Fact]
    public void PlayerTable_ShouldThrowException_WhenTableIsBig()
    {
        // Arrange
        PlayerTable.TableBuilder table = PlayerTable.TableBuilder.Builder;

        // Act
        for (int i = 0; i < 7; ++i)
        {
            table.AddCreature(new AngryFighterBuilder().WithBaseStats(new Health(6), new Attack(1))
                .Build());
        }

        // Assert
        Assert.Throws<ArgumentException>(() => table.AddCreature(new ImmortalHorrorBuilder()
            .WithBaseStats(new Health(4), new Attack(4))
            .Build()));
    }
}