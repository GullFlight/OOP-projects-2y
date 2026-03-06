namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public record Health(int Value)
{
    public Health Increase(int increase) => new Health(Value + increase);

    public Health Decrease(int decrease) => new Health(Value - decrease);
}