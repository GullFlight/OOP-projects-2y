using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Operations;

public abstract class OperationBase
{
    public OperationType Id { get; init; }

    public Money Amount { get; }

    public abstract void Execute(Account account);

    protected OperationBase(Money amount)
    {
        Amount = amount;
    }
}