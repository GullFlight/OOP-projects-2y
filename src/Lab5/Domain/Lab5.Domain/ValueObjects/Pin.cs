namespace Lab5.Domain.ValueObjects;

public sealed record Pin
{
    public Pin(string value)
    {
        if (value.Length != 4 && !int.TryParse(value, out _))
            throw new ArgumentException("Pin must contain exactly 4 characters");

        Value = value;
    }

    public string Value { get; }
}
