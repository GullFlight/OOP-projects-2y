using Lab5.Application.Abstractions;
using Lab5.Application.Contracts.Operations;
using Lab5.Application.Contracts.Services;
using Lab5.Application.Mapping;
using Lab5.Domain;
using Lab5.Domain.Operations;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Services;

public class AccountService : IAccountService
{
    private readonly IPersistenceContext _context;

    public AccountService(IPersistenceContext context)
    {
        _context = context;
    }

    public CreateAccount.Response CreateAccount(CreateAccount.Request request)
    {
        var account = new Account(request.AccountNumber, new Money(0), request.Pin);
        _context.AccountRepository.Add(account);

        return new CreateAccount.Response.Success(account.MapToDto());
    }

    public Deposit.Response Deposit(Deposit.Request request)
    {
        Account account = _context.AccountRepository.GetByNumber(request.Id);
        account.Deposit(request.Money);
        var operation = new DepositOperation(request.Money);
        _context.OperationRepository.Add(operation);

        return new Deposit.Response.Success(account.MapToDto());
    }

    public Withdraw.Response Withdraw(Withdraw.Request request)
    {
        Account account = _context.AccountRepository.GetByNumber(request.Id);
        account.Withdraw(request.Money);
        var operation = new WithdrawOperation(request.Money);
        _context.OperationRepository.Add(operation);

        return new Withdraw.Response.Success(account.MapToDto());
    }

    public GetBalance.Response GetBalance(GetBalance.Request request)
    {
        Account account = _context.AccountRepository.GetByNumber(request.Id);
        Money amount = account.Amount;
        return new GetBalance.Response.Success(account.MapToDto());
    }

    public Account GetHistory(CreateAccount.Request request)
    {
        return _context.AccountRepository.GetByNumber(request.AccountNumber);
    }
}