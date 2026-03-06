namespace Itmo.ObjectOrientedProgramming.Lab1;

public record Mass
{
    public Mass(double kilograms)
    {
        if (kilograms < 0)
            throw new ArgumentException("The mass cannot be negative.");

        Value = kilograms;
    }

    public double Value { get; }
}