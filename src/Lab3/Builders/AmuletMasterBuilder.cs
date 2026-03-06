using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class AmuletMasterBuilder : CreatureBuilder
{
    public ICreatureBuilder CreateDefault()
    {
        return new AmuletMasterBuilder()
            .WithBaseStats(new Health(2), new Attack(5))
            .WithModifier(new MagicShieldApplier())
            .WithModifier(new DoubleAttackApplier());
    }

    protected override ICreature CreateCreature(int health, int attack)
    {
        return new AmuletMaster(health, attack);
    }
}