namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public record Attack(int Value)
{
    public Attack Increase(int increase) => new Attack(Value + increase);
}