using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PopApp.dk.DataAccess.DataContext;
using PopApp.dk.DataAccess.Repositories;
using PopApp.dk.DataAccess.Repositories.IRepositories;

namespace PopApp.dk.DataAccess;

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