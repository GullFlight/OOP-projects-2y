using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders.Factory;

public class WarAnalystFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder Create()
    {
        return new WarAnalystBuilder()
            .WithBaseStats(new Health(4), new Attack(2));
    }
}