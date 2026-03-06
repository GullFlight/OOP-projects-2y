using Lab5.Application.Abstractions;
using Lab5.Application.Abstractions.Repositories;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly Dictionary<Guid, ISessionContext> _sessionContexts = [];

    public void Add(ISessionContext sessionContext)
    {
        _sessionContexts[sessionContext.SessionId] = sessionContext;
    }

    public IEnumerable<ISessionContext> GetById(Guid id)
    {
        return _sessionContexts.Values.Where(s => s.SessionId == id);
    }
}