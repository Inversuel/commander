using commander.application.Infrastructure.Services;
using commander.application.Interface.Authentication;
using commander.application.Interface.Services;
using commander.infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace commander.infrastructure;

public static class DepedencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}