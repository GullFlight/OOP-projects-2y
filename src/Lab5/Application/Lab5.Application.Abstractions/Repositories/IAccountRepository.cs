using Lab5.Domain;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    Account GetById(Guid id);

    Account GetByNumber(string number);

    void Add(Account account);
}