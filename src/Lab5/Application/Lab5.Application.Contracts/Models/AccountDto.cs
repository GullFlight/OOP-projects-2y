using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Contracts.Models;

public record AccountDto(Money Money, Guid Id);