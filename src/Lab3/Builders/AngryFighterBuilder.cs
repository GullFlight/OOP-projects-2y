using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class AngryFighterBuilder : CreatureBuilder
{
    protected override ICreature CreateCreature(int health, int attack)
    {
        return new AngryFighter(health, attack);
    }
}