using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class MagicMirror : ICreature
{
    public Health Health => new Health(_creature.Attack.Value);

    public Attack Attack => new Attack(_creature.Health.Value);

    public bool IsAlive => Health.Value > 0;

    private readonly ICreature _creature;

    public MagicMirror(ICreature creature)
    {
        _creature = creature;
    }

    public void IncreaseHealth(int increase) => _creature.IncreaseHealth(increase);

    public void IncreaseAttack(int increase) => _creature.IncreaseAttack(increase);

    public void GetDamage(ICreature creature)
    {
        _creature.GetDamage(creature);
    }

    public void Attacking(ICreature creature)
    {
        if (creature.Health.Value > 0)
            _creature.Attacking(creature);
    }

    public ICreature Clone()
    {
        _creature.Clone();
        return _creature;
    }
}