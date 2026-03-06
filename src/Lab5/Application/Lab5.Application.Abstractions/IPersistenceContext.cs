using Lab5.Application.Abstractions.Repositories;

namespace Lab5.Application.Abstractions;

public interface IPersistenceContext
{
    IAccountRepository AccountRepository { get; }

    ISessionRepository SessionRepository { get; }

    IOperationRepository OperationRepository { get; }
}