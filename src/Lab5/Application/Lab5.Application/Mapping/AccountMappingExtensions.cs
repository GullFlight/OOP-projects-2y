using Lab5.Application.Contracts.Models;
using Lab5.Domain;

namespace Lab5.Application.Mapping;

public static class AccountMappingExtensions
{
    public static AccountDto MapToDto(this Account account)
        => new AccountDto(account.Amount, account.Id);
}