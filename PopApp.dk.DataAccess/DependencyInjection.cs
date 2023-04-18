using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POPAPP.DK.DATA.DataContext;
using POPAPP.DK.DATA.Repositories;
using POPAPP.DK.DATA.Repositories.IRepositories;

namespace POPAPP.DK.DATA;

public static class DependencyInjection
{
    public static void RegisterDataDependencies(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<PopappDbContext>(options =>
        {
            options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IAccountRepository, AccountRepository>();
    }
}