namespace Itmo.ObjectOrientedProgramming.Lab1;

public record Acceleration
{
    public Acceleration(double metersPerSecondSquared)
    {
        Value = metersPerSecondSquared;
    }

    public double Value { get; }
}
