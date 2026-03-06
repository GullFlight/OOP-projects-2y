using Lab5.Application.Abstractions;
using Lab5.Application.Contracts.Operations;
using Lab5.Application.Services;
using Lab5.Domain;
using Lab5.Domain.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class AccountServiceTest
{
    private readonly IPersistenceContext _persistenceContext;

    private readonly AccountService _accountService;

    public AccountServiceTest()
    {
        _persistenceContext = Substitute.For<IPersistenceContext>();
        _accountService = new AccountService(_persistenceContext);
    }

    [Fact]
    public void Deposit_WithValidAmount_ShouldUpdateBalance()
    {
        // Arrange
        var account = new Account("12345", new Money(150), new Pin("1234"));
        _persistenceContext.AccountRepository.GetByNumber("12345").Returns(account);

        var request = new Deposit.Request("12345", new Money(50));

        // Act
        Deposit.Response result = _accountService.Deposit(request);

        // Assert
        Assert.IsType<Deposit.Response.Success>(result);
        Assert.Equal(200, account.Amount.Value);
    }

    [Fact]
    public void Deposit_WithNoValidAmount_ShouldNotUpdateBalance()
    {
        // Arrange
        var account = new Account("12345", new Money(150), new Pin("1234"));
        _persistenceContext.AccountRepository.GetByNumber("12345").Returns(account);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _accountService.Deposit(new Deposit.Request("12345", new Money(-50))));
    }

    [Fact]
    public void WithDraw_WithValidAmount_ShouldUpdateBalance()
    {
        // Arrange
        var account = new Account("12345", new Money(150), new Pin("1234"));
        _persistenceContext.AccountRepository.GetByNumber("12345").Returns(account);

        var request = new Withdraw.Request("12345", new Money(50));

        // Act
        Withdraw.Response result = _accountService.Withdraw(request);

        // Assert
        Assert.IsType<Withdraw.Response.Success>(result);
        Assert.Equal(100, account.Amount.Value);
    }

    [Fact]
    public void Withdraw_WithValidAmount_ShouldNotUpdateBalance()
    {
        // Arrange
        var account = new Account("12345", new Money(150), new Pin("1234"));
        _persistenceContext.AccountRepository.GetByNumber("12345").Returns(account);

        var request = new Withdraw.Request("12345", new Money(90));

        // Act
        Withdraw.Response result = _accountService.Withdraw(request);

        // Assert
        Assert.IsType<Withdraw.Response.Success>(result);
        Assert.Equal(60, account.Amount.Value);
    }

    [Fact]
    public void Withdraw_WithValidAmount_ShouldNotUpdateBalanceAndThrownException()
    {
        // Arrange
        var account = new Account("12345", new Money(150), new Pin("1234"));
        _persistenceContext.AccountRepository.GetByNumber("12345").Returns(account);

        var request = new Withdraw.Request("12345", new Money(200));

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _accountService.Withdraw(request));
    }
}