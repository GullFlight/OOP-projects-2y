using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class AngryFighter : BaseCreature
{
    public AngryFighter(int health, int attack) : base(health, attack) { }

    public override void Attacking(ICreature creature)
    {
        creature.GetDamage(this);
    }

    public override void GetDamage(ICreature creature)
    {
        Health = Health.Decrease(creature.Attack.Value);

        if (IsAlive)

            Attack = Attack.Increase(Attack.Value);
    }

    public override ICreature Clone()
    {
        return new AngryFighter(Attack.Value, Health.Value);
    }
}