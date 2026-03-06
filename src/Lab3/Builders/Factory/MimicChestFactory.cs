using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders.Factory;

public class MimicChestFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder Create()
    {
        return new MimicChestBuilder()
            .WithBaseStats(new Health(1), new Attack(1));
    }
}