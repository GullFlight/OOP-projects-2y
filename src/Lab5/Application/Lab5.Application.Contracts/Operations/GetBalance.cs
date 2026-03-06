using Lab5.Application.Contracts.Models;

namespace Lab5.Application.Contracts.Operations;

public static class GetBalance
{
    public readonly record struct Request(string Id);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(AccountDto Order) : Response;

        public sealed record Failure(string Message) : Response;
    }
}