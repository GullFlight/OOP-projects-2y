using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class AmuletMaster : BaseCreature
{
    public AmuletMaster(int health, int attack) : base(health, attack) { }

    public override void Attacking(ICreature creature)
    {
        creature.GetDamage(this);
    }

    public override void GetDamage(ICreature creature)
    {
        Health = Health.Decrease(creature.Attack.Value);
    }

    public override ICreature Clone()
    {
        return new AmuletMaster(Attack.Value, Health.Value);
    }
}