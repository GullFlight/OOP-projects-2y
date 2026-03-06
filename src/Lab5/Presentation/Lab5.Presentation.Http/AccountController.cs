using Lab5.Application.Contracts.Models;
using Lab5.Application.Contracts.Operations;
using Lab5.Application.Contracts.Services;
using Lab5.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Presentation.Http;

[ApiController]
[Route("/api/account")]
public sealed class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    private readonly ISessionService _sessionService;

    public AccountController(IAccountService accountService, ISessionService sessionService)
    {
        _accountService = accountService;
        _sessionService = sessionService;
    }

    [HttpPost("create")]
    public ActionResult<AccountDto> Create(
        [FromBody] CreateAccount.Request httpRequest)
    {
        var request = new CreateAccount.Request(
            httpRequest.AccountNumber,
            httpRequest.Pin);

        CreateAccount.Response response = _accountService.CreateAccount(request);

        return response switch
        {
            CreateAccount.Response.Success s => Ok(s.Order),
            CreateAccount.Response.Failure => Conflict(),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("user")]
    public ActionResult<SessionDto> CreateUserSession([FromBody] CreateSession.UserRequest httpRequest)
    {
        var request = new CreateSession.UserRequest(httpRequest.AccountNumber, httpRequest.Pin);

        CreateSession.Response response = _sessionService.CreateUserSession(request);

        return response switch
        {
            CreateSession.Response.Success success => Ok(success.Order.Id),
            CreateSession.Response.Failure failure => Unauthorized(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("admin")]
    public ActionResult<SessionDto> CreateAdminSession([FromBody] CreateSession.AdminRequest httpRequest)
    {
        var request = new CreateSession.AdminRequest(httpRequest.Password);

        CreateSession.Response response = _sessionService.CreateAdminSession(request);

        return response switch
        {
            CreateSession.Response.Success success => Ok(success.Order.Id),
            CreateSession.Response.Failure failure => Unauthorized(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("deposit")]
    public ActionResult<AccountBalanceDto> Deposit(string accountNumber, [FromBody] Money amount)
    {
        var request = new Deposit.Request(accountNumber, amount);
        Deposit.Response response = _accountService.Deposit(request);

        return response switch
        {
            Deposit.Response.Success success => Ok(success.Order.Money),
            Deposit.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("withdraw")]
    public ActionResult<AccountBalanceDto> Withdraw(string accountNumber, [FromBody] Money amount)
    {
        var request = new Withdraw.Request(accountNumber, amount);
        Withdraw.Response response = _accountService.Withdraw(request);

        return response switch
        {
            Withdraw.Response.Success success => Ok(success.Order.Money),
            Withdraw.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpGet("balance")]
    public ActionResult<AccountBalanceDto> GetBalance(string accountNumber)
    {
        var request = new GetBalance.Request(accountNumber);
        GetBalance.Response response = _accountService.GetBalance(request);

        return response switch
        {
            GetBalance.Response.Success success => Ok(success.Order.Money),
            GetBalance.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }
}