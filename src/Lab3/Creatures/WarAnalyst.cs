using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class WarAnalyst : BaseCreature
{
    public WarAnalyst(int health, int attack) : base(health, attack) { }

    public override void Attacking(ICreature creature)
    {
        Attack = Attack.Increase(2);
        creature.GetDamage(this);
    }

    public override void GetDamage(ICreature creature)
    {
        Health = Health.Decrease(creature.Attack.Value);
    }

    public override ICreature Clone()
    {
        return new WarAnalyst(Attack.Value, Health.Value);
    }
}