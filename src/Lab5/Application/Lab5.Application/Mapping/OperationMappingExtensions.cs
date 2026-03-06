using Lab5.Application.Contracts.Models;
using Lab5.Domain.Operations;

namespace Lab5.Application.Mapping;

public static class OperationMappingExtensions
{
    public static OperationDto MapToDto(this OperationBase operation)
        => new OperationDto(operation.Amount);
}