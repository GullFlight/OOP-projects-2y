using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class ImmortalHorror : BaseCreature
{
    private bool _hasReborn;

    public ImmortalHorror(int health, int attack) : base(health, attack)
    {
        _hasReborn = false;
    }

    public override void GetDamage(ICreature creature)
    {
        Health = Health.Decrease(creature.Attack.Value);

        if (Health.Value <= 0 && !_hasReborn)
        {
            Health = new Health(1);
            _hasReborn = true;
        }
    }

    public override void Attacking(ICreature creature)
    {
        creature.GetDamage(this);
    }

    public override ICreature Clone()
    {
        return new ImmortalHorror(Attack.Value, Health.Value);
    }
}