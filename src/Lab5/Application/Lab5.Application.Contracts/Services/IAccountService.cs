using Lab5.Application.Contracts.Operations;
using Lab5.Domain;

namespace Lab5.Application.Contracts.Services;

public interface IAccountService
{
    CreateAccount.Response CreateAccount(CreateAccount.Request request);

    Withdraw.Response Withdraw(Withdraw.Request request);

    Deposit.Response Deposit(Deposit.Request request);

    GetBalance.Response GetBalance(GetBalance.Request request);

    Account GetHistory(CreateAccount.Request request);
}