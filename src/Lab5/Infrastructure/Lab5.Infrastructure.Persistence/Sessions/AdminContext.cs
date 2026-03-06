using Lab5.Application.Abstractions;

namespace Lab5.Infrastructure.Persistence.Sessions;

public class AdminContext : ISessionContext
{
    public Guid SessionId { get; }

    public string AccountNumber { get; }

    public AdminContext(string accountNumber)
    {
        SessionId = Guid.NewGuid();
        AccountNumber = accountNumber;
    }

    public bool HaveAccess(string accountNumber) => true;
}