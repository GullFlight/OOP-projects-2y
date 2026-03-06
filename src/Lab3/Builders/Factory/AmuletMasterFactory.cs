using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders.Factory;

public class AmuletMasterFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder Create()
    {
        return new AmuletMasterBuilder()
            .WithBaseStats(new Health(2), new Attack(5))
            .WithModifier(new MagicShieldApplier())
            .WithModifier(new DoubleAttackApplier());
    }
}