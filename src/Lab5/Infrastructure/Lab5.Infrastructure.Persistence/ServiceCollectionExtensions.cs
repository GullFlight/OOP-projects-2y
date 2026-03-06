using Lab5.Application.Abstractions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Infrastructure.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection services)
    {
        services.AddSingleton<IAccountRepository, AccountRepository>();
        services.AddSingleton<ISessionRepository, SessionRepository>();
        services.AddSingleton<IOperationRepository, OperationRepository>();

        services.AddScoped<IPersistenceContext, PersistenceContext>();
        return services;
    }
}