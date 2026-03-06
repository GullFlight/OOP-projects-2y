using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders.Factory;

public class AngryFighterFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder Create()
    {
        return new AngryFighterBuilder()
            .WithBaseStats(new Health(6), new Attack(1));
    }
}