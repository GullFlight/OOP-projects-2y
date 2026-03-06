using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public interface IModifierApplier
{
    ICreature Apply(ICreature creature);
}