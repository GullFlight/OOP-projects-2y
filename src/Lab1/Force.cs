namespace Itmo.ObjectOrientedProgramming.Lab1;

public record Force
{
    public Force(double newtons)
    {
        Value = newtons;
    }

    public double Value { get; }
}
