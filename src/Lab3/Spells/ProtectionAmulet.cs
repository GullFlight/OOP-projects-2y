using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class ProtectionAmulet
{
    public ICreature ApplyTo(ICreature creature)
    {
        creature = new MagicalShieldModifier(creature);
        return creature;
    }
}