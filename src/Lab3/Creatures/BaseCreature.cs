using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public abstract class BaseCreature : ICreature
{
    protected BaseCreature(int health, int attack)
    {
        Health = new Health(health);
        Attack = new Attack(attack);
    }

    public Health Health { get; protected set; }

    public Attack Attack { get; protected set; }

    public bool IsAlive => Health.Value > 0;

    public abstract void Attacking(ICreature creature);

    public abstract void GetDamage(ICreature creature);

    public abstract ICreature Clone();

    public void IncreaseHealth(int increase)
    {
        Health = Health.Increase(increase);
    }

    public void IncreaseAttack(int increase)
    {
        Attack = Attack.Increase(increase);
    }
}