using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly Dictionary<Guid, Account> _accounts = [];
    private readonly Dictionary<string, Account> _accountsByNumber = [];

    public void Add(Account account)
    {
        _accounts[account.Id] = account;
        _accountsByNumber[account.AccountNumber] = account;
    }

    public Account GetById(Guid id)
    {
        return _accounts[id];
    }

    public Account GetByNumber(string number)
    {
        return _accountsByNumber[number];
    }
}