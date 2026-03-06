using Lab5.Application.Contracts.Services;
using Lab5.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAccountService, AccountService>();
        collection.AddScoped<ISessionService, SessionService>();
        collection.AddScoped<IOperationService, OperationService>();

        return collection;
    }
}