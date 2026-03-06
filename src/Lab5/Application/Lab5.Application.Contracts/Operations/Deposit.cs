using Lab5.Application.Contracts.Models;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Contracts.Operations;

public static class Deposit
{
    public readonly record struct Request(string Id, Money Money);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(AccountDto Order) : Response;

        public sealed record Failure(string Message) : Response;
    }
}