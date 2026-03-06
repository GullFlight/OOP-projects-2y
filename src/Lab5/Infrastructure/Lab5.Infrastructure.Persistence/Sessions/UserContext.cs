using Lab5.Application.Abstractions;

namespace Lab5.Infrastructure.Persistence.Sessions;

public class UserContext : ISessionContext
{
    public Guid SessionId { get; }

    public string AccountNumber { get; }

    public UserContext(string accountNumber)
    {
        SessionId = Guid.NewGuid();
        AccountNumber = accountNumber;
    }

    public bool HaveAccess(string accountNumber) => AccountNumber == accountNumber;
}