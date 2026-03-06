using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class StaminaPotion
{
    public ICreature ApplyTo(ICreature creature)
    {
        creature.IncreaseHealth(5);
        return creature;
    }
}