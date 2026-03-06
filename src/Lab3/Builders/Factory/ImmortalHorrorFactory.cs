using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders.Factory;

public class ImmortalHorrorFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder Create()
    {
        return new ImmortalHorrorBuilder().WithBaseStats(new Health(4), new Attack(4));
    }
}