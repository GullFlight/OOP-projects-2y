using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Operations;

public class WithdrawOperation : OperationBase
{
    public WithdrawOperation(Money amount) : base(amount)
    {
        Id = OperationType.Withdraw;
    }

    public override void Execute(Account account)
    {
        account.Withdraw(Amount);
    }
}