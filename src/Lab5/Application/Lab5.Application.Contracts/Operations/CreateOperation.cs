using Lab5.Application.Contracts.Models;
using Lab5.Domain.Operations;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Contracts.Operations;

public static class CreateOperation
{
    public readonly record struct Request(OperationType Id, Money Money);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(OperationDto Order) : Response;

        public sealed record Failure(string Message) : Response;
    }
}