using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PopApp.dk.Business.Services;
using PopApp.dk.Business.Services.IServices;

namespace PopApp.dk.Business;

public static class DependencyInjection
{
    
    public static void RegisterBusinessLogicDependencies(this IServiceCollection services, IConfiguration Configuration)
    {
        // services.AddAutoMapper(typeof(AutoMapperProfiles));
        services.AddScoped<IAccountService, AccountService>();
        // services.AddScoped<IAuthService, AuthService>();
    }
}