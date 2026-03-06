using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class ImmortalHorrorBuilder : CreatureBuilder
{
    protected override ICreature CreateCreature(int health, int attack)
    {
        return new ImmortalHorror(health, attack);
    }
}