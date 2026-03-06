namespace Itmo.ObjectOrientedProgramming.Lab1;

public record Distance
{
    public Distance(double meters)
    {
        if (meters < 0)
            throw new ArgumentException("The distance cannot be negative.");

        Value = meters;
    }

    public double Value { get; }
}
