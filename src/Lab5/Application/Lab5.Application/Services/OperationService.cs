using Lab5.Application.Abstractions;
using Lab5.Application.Contracts.Operations;
using Lab5.Application.Contracts.Services;
using Lab5.Application.Mapping;
using Lab5.Domain;
using Lab5.Domain.Operations;

namespace Lab5.Application.Services;

public class OperationService : IOperationService
{
    private readonly IPersistenceContext _context;

    public OperationService(IPersistenceContext context)
    {
        _context = context;
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

    public IEnumerable<OperationBase> GetOperationHistory(CreateOperation.Request request)
    {
        return _context.OperationRepository.GetById(request.Id);
    }
}