using Example.Application.Interfaces;
using Example.Infrastructure.Persistence;
using Example.Infrastructure.Repositories;
using Example.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}