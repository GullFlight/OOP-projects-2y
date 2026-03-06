using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class PowerPotion : ISpell
{
    public ICreature ApplyTo(ICreature creature)
    {
        creature.IncreaseAttack(5);
        return creature;
    }
}