using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Battlefield;

public class PlayerTable
{
    private readonly IRandom _random;

    private PlayerTable(IEnumerable<ICreature> creatures, IRandom random)
    {
        Creatures = creatures.ToList();
        _random = random;
    }

    public PlayerTable Clone()
    {
        var clonedCreatures = Creatures.Select(c => c.Clone()).ToList();
        return new PlayerTable(clonedCreatures, _random);
    }

    private IEnumerable<ICreature> Creatures { get; }

    public ICreature? GetRandomAttackingCreature()
    {
        var attackingCreature =
            Creatures.Where(creature => creature.IsAlive && creature.Attack.Value > 0).ToList();
        if (attackingCreature.Count == 0)
            return null;
        return attackingCreature[Math.Abs(_random.RandomNumber(attackingCreature.Count))];
    }

    public ICreature? GetRandomTargetCreature()
    {
        var defendingCreature = Creatures.Where(creature => creature.IsAlive).ToList();
        if (defendingCreature.Count == 0)
            return null;
        return defendingCreature[Math.Abs(_random.RandomNumber(defendingCreature.Count))];
    }

    public class TableBuilder
    {
        private const int MaxCreatureCount = 7;
        private readonly List<ICreature> _creatures = [];
        private readonly IRandom _random = new Randomizer(MaxCreatureCount);

        public TableBuilder AddCreature(ICreature creature)
        {
            if (_creatures.Count is MaxCreatureCount)
                throw new ArgumentException("Too much creatures");
            _creatures.Add(creature);
            return this;
        }

        public static TableBuilder Builder => new TableBuilder();

        public PlayerTable Build() { return new PlayerTable(_creatures.ToArray(), _random); }
    }
}