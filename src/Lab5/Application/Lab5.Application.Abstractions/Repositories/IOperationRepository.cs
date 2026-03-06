using Lab5.Domain.Operations;

namespace Lab5.Application.Abstractions.Repositories;

public interface IOperationRepository
{
    IEnumerable<OperationBase> GetById(OperationType id);

    void Add(OperationBase operation);
}