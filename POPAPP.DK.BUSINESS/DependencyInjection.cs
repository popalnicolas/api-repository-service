using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POPAPP.DK.BUSINESS.Services;
using POPAPP.DK.BUSINESS.Services.IServices;

namespace POPAPP.DK.BUSINESS;

public static class DependencyInjection
{
    
    public static void RegisterBusinessLogicDependencies(this IServiceCollection services, IConfiguration Configuration)
    {
        // services.AddAutoMapper(typeof(AutoMapperProfiles));
        services.AddScoped<IAccountService, AccountService>();
        // services.AddScoped<IAuthService, AuthService>();
    }
}