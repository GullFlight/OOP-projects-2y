using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class DoubleAttackModifier : ICreature
{
    public Health Health { get; }

    public Attack Attack { get; }

    public bool IsAlive => Health.Value > 0;

    private readonly ICreature _creature;

    private bool _usedDoubleAttack;

    public DoubleAttackModifier(ICreature creature, bool usedDoubleAttack = false)
    {
        _creature = creature;
        Health = _creature.Health;
        Attack = _creature.Attack;
        _usedDoubleAttack = usedDoubleAttack;
    }

    public void IncreaseHealth(int increase) => _creature.IncreaseHealth(increase);

    public void IncreaseAttack(int increase) => _creature.IncreaseAttack(increase);

    public void GetDamage(ICreature creature)
    {
        _creature.GetDamage(creature);
    }

    public void Attacking(ICreature creature)
    {
        _creature.Attacking(creature);
        if (creature.IsAlive && !_usedDoubleAttack)
            _creature.Attacking(creature);
        _usedDoubleAttack = true;
    }

    public ICreature Clone()
    {
        return new DoubleAttackModifier(_creature.Clone(), _usedDoubleAttack);
    }
}