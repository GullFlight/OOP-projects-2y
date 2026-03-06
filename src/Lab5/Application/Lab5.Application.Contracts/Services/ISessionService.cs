using Lab5.Application.Contracts.Operations;

namespace Lab5.Application.Contracts.Services;

public interface ISessionService
{
    CreateSession.Response CreateUserSession(CreateSession.UserRequest request);

    CreateSession.Response CreateAdminSession(CreateSession.AdminRequest request);
}