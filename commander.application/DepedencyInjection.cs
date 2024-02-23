using commander.application.Interface.Authentication;
using commander.application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace commander.application;

public static class DepedencyInjection{
    public static IServiceCollection AddApplication(this IServiceCollection services){
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}