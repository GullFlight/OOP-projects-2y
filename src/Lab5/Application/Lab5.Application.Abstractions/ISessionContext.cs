namespace Lab5.Application.Abstractions;

public interface ISessionContext
{
    Guid SessionId { get; }

    string AccountNumber { get; }

    bool HaveAccess(string accountNumber);
}