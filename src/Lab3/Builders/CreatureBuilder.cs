using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public abstract class CreatureBuilder : ICreatureBuilder
{
    private readonly List<IModifierApplier> _modifiers = new();
    private Health? _health;
    private Attack? _attack;

    public ICreatureBuilder WithBaseStats(Health health, Attack attack)
    {
        _health = health;
        _attack = attack;
        return this;
    }

    public ICreatureBuilder WithModifier(IModifierApplier modifier)
    {
        _modifiers.Add(modifier);
        return this;
    }

    public ICreature Build()
    {
        if (_health is null || _attack is null)
            throw new InvalidOperationException("Health and Attack must be set");

        ICreature creature = CreateCreature(_health.Value, _attack.Value);

        foreach (IModifierApplier modifier in _modifiers)
        {
            creature = modifier.Apply(creature);
        }

        return creature;
    }

    protected abstract ICreature CreateCreature(int health, int attack);
}