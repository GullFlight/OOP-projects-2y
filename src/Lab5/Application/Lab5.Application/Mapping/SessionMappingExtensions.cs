using Lab5.Application.Abstractions;
using Lab5.Application.Contracts.Models;

namespace Lab5.Application.Mapping;

public static class SessionMappingExtensions
{
    public static SessionDto MapToDto(this ISessionContext session)
        => new SessionDto(session.SessionId);
}