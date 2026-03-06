using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class MagicShieldApplier : IModifierApplier
{
    public ICreature Apply(ICreature creature)
    {
        return new MagicalShieldModifier(creature);
    }
}