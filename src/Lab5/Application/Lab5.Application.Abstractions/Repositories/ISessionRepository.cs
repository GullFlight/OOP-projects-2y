namespace Lab5.Application.Abstractions.Repositories;

public interface ISessionRepository
{
    IEnumerable<ISessionContext> GetById(Guid id);

    void Add(ISessionContext sessionContext);
}