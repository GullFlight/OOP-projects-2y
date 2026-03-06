namespace Lab5.Domain.ValueObjects;

public sealed record Money
{
    public Money(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("Money must be positive");

        Value = value;
    }

    public decimal Value { get; }

    public static Money operator +(Money left, Money right) => new(left.Value + right.Value);

    public static Money operator -(Money left, Money right) => new(left.Value - right.Value);
}