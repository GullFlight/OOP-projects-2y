using Lab5.Domain.ValueObjects;

namespace Lab5.Domain;

public class Account
{
    public string AccountNumber { get; }

    public Guid Id { get; }

    public Money Amount { get; private set; }

    private Pin Pin { get; }

    public Account(string accountNumber, Money amount, Pin pin)
    {
        AccountNumber = accountNumber;
        Id = Guid.NewGuid();
        Amount = amount;
        Pin = pin;
    }

    public void Withdraw(Money amount)
    {
        Amount = Amount - amount;
    }

    public void Deposit(Money amount)
    {
        Amount = Amount + amount;
    }

    public bool Verify(Pin pin) => Pin == pin;
}