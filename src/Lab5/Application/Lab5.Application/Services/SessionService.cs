using Lab5.Application.Abstractions;
using Lab5.Application.Contracts.Operations;
using Lab5.Application.Contracts.Services;
using Lab5.Application.Mapping;
using Lab5.Domain;
using Lab5.Infrastructure.Persistence.Sessions;
using Microsoft.Extensions.Options;

namespace Lab5.Application.Services;

public class SessionService : ISessionService
{
    private readonly IPersistenceContext _context;

    private readonly string _adminPassword;

    public SessionService(IOptions<AdminPassword> password, IPersistenceContext context)
    {
        _adminPassword = password.Value.Password;
        _context = context;
    }

    public CreateSession.Response CreateAdminSession(CreateSession.AdminRequest request)
    {
        if (_adminPassword != request.Password)
        {
            return new CreateSession.Response.Failure("Wrong password");
        }

        var admin = new AdminContext(request.Password);
        _context.SessionRepository.Add(admin);
        return new CreateSession.Response.Success(admin.MapToDto());
    }

    public CreateSession.Response CreateUserSession(CreateSession.UserRequest request)
    {
        Account account = _context.AccountRepository.GetByNumber(request.AccountNumber);
        if (!account.Verify(request.Pin))
            return new CreateSession.Response.Failure("Incorrect pin");

        var user = new UserContext(request.AccountNumber);
        _context.SessionRepository.Add(user);
        return new CreateSession.Response.Success(user.MapToDto());
    }
}