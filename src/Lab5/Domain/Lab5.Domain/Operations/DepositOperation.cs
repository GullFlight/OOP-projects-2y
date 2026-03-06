using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Operations;

public class DepositOperation : OperationBase
{
    public DepositOperation(Money amount) : base(amount)
    {
        Id = OperationType.Deposit;
    }

    public override void Execute(Account account)
    {
        account.Deposit(Amount);
    }
}