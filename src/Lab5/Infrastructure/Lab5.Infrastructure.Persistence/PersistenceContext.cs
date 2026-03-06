using Lab5.Application.Abstractions;
using Lab5.Application.Abstractions.Repositories;

namespace Lab5.Infrastructure.Persistence;

public class PersistenceContext : IPersistenceContext
{
    public IAccountRepository AccountRepository { get; }

    public ISessionRepository SessionRepository { get; }

    public IOperationRepository OperationRepository { get; }

    public PersistenceContext(
        IAccountRepository accountRepository,
        ISessionRepository sessionRepository,
        IOperationRepository operationRepository)
    {
        AccountRepository = accountRepository;
        SessionRepository = sessionRepository;
        OperationRepository = operationRepository;
    }
}