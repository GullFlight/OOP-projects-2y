using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Operations;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class OperationRepository : IOperationRepository
{
    private readonly Dictionary<OperationType, OperationBase> _operations = [];

    public void Add(OperationBase operation)
    {
        _operations[operation.Id] = operation;
    }

    public IEnumerable<OperationBase> GetById(OperationType id)
    {
        return _operations.Values.Where(s => s.Id == id);
    }
}