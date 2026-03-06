using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class MimicChest : BaseCreature
{
    public MimicChest(int health, int attack) : base(health, attack) { }

    public override void Attacking(ICreature creature)
    {
        Attack = new Attack(Math.Max(Attack.Value, creature.Attack.Value));
        Health = new Health(Math.Max(Health.Value, creature.Health.Value));
        creature.GetDamage(this);
    }

    public override void GetDamage(ICreature creature)
    {
        Health = Health.Decrease(creature.Attack.Value);
    }

    public override ICreature Clone()
    {
        return new MimicChest(Attack.Value, Health.Value);
    }
}