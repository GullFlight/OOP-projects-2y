using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class MagicalShieldModifier : ICreature
{
    public Health Health { get; }

    public Attack Attack { get; }

    public bool IsAlive => Health.Value > 0;

    private readonly ICreature _creature;

    private bool _usedShield;

    public MagicalShieldModifier(ICreature creature, bool usedShield = false)
    {
        _creature = creature;
        Health = _creature.Health;
        Attack = _creature.Attack;
        _usedShield = usedShield;
    }

    public void GetDamage(ICreature creature)
    {
        if (!_usedShield)
        {
            _usedShield = true;
            return;
        }

        _creature.GetDamage(creature);
    }

    public void IncreaseHealth(int increase) => _creature.IncreaseHealth(increase);

    public void IncreaseAttack(int increase) => _creature.IncreaseAttack(increase);

    public void Attacking(ICreature creature)
    {
        _creature.Attacking(creature);
    }

    public ICreature Clone()
    {
        return new MagicalShieldModifier(_creature.Clone(), _usedShield);
    }
}