using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public interface ICreatureBuilder
{
    ICreature Build();

    ICreatureBuilder WithModifier(IModifierApplier modifier);

    ICreatureBuilder WithBaseStats(Health health, Attack attack);
}