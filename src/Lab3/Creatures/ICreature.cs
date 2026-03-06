using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public interface ICreature
{
    Health Health { get; }

    Attack Attack { get; }

    bool IsAlive { get; }

    void GetDamage(ICreature creature);

    void Attacking(ICreature creature);

    ICreature Clone();

    void IncreaseHealth(int increase);

    void IncreaseAttack(int increase);
}