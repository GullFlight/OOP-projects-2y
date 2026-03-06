namespace Itmo.ObjectOrientedProgramming.Lab1;

public record Time
{
    public Time(double seconds)
    {
        if (seconds < 0)
            throw new ArgumentException("The time cannot be negative.");

        Value = seconds;
    }

    public double Value { get; }
}
