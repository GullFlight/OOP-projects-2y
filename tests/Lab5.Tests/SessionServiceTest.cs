using Lab5.Application.Abstractions;
using Lab5.Application.Contracts.Operations;
using Lab5.Application.Services;
using Lab5.Domain;
using Lab5.Domain.ValueObjects;
using Lab5.Infrastructure.Persistence.Sessions;
using Microsoft.Extensions.Options;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class SessionServiceTest
{
    private readonly IPersistenceContext _persistenceContext;

    private readonly SessionService _sessionService;

    public SessionServiceTest()
    {
        _persistenceContext = Substitute.For<IPersistenceContext>();
        _sessionService = new SessionService(Options.Create(new AdminPassword("admin12")), _persistenceContext);
    }

    [Fact]
    public void CreateUserSession_WithValidData_ShouldCreateNewSession()
    {
        // Arrange
        var account = new Account("123", new Money(100), new Pin("9090"));
        _persistenceContext.AccountRepository.GetByNumber("123").Returns(account);

        var request = new CreateSession.UserRequest("123", new Pin("9090"));

        // Act
        CreateSession.Response result = _sessionService.CreateUserSession(request);

        // Assert
        Assert.IsType<CreateSession.UserRequest>(request);
        Assert.IsType<CreateSession.Response.Success>(result);
        _persistenceContext.SessionRepository.Received(1).Add(Arg.Any<UserContext>());
    }

    [Fact]
    public void CreateUserSession_WithWrongPin_ReturnFailure()
    {
        // Arrange
        var account = new Account("123", new Money(100), new Pin("9090"));
        _persistenceContext.AccountRepository.GetByNumber("123").Returns(account);

        var request = new CreateSession.UserRequest("123", new Pin("9999"));

        // Act
        CreateSession.Response result = _sessionService.CreateUserSession(request);

        // Assert
        Assert.IsType<CreateSession.Response.Failure>(result);
    }

    [Fact]
    public void CreateAdminSession_WithCorrectPassWord_ShouldReturnSuccess()
    {
        // Arrange
        var request = new CreateSession.AdminRequest("admin12");

        // Act
        CreateSession.Response result = _sessionService.CreateAdminSession(request);

        // Assert
        Assert.IsType<CreateSession.Response.Success>(result);
    }

    [Fact]
    public void CreateAdminSession_WithInCorrectPassWord_ShouldReturnFailure()
    {
        // Arrange
        var request = new CreateSession.AdminRequest("apple");

        // Act
        CreateSession.Response result = _sessionService.CreateAdminSession(request);

        // Assert
        Assert.IsType<CreateSession.Response.Failure>(result);
    }
}