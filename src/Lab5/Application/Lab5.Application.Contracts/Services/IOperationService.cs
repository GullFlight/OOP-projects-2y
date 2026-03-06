using Lab5.Application.Contracts.Operations;
using Lab5.Domain.Operations;

namespace Lab5.Application.Contracts.Services;

public interface IOperationService
{
    Withdraw.Response Withdraw(Withdraw.Request request);

    Deposit.Response Deposit(Deposit.Request request);

    IEnumerable<OperationBase> GetOperationHistory(CreateOperation.Request request);
}