using Lab5.Application.Contracts.Models;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Contracts.Operations;

public static class CreateSession
{
    public readonly record struct AdminRequest(string Password);

    public readonly record struct UserRequest(string AccountNumber, Pin Pin);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(SessionDto Order) : Response;

        public sealed record Failure(string Message) : Response;
    }
}
