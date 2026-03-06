namespace Itmo.ObjectOrientedProgramming.Lab1;

public record Speed
{
    public Speed(double metersPerSecond)
    {
        Value = metersPerSecond;
    }

    public double Value { get; }
}
