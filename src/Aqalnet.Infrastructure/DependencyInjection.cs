using Aqalnet.Application.Abstractions.Caching;
using Aqalnet.Application.Abstractions.Data;
using Aqalnet.Application.Abstractions.Email;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Companies;
using Aqalnet.Domain.Propertys;
using Aqalnet.Domain.Users;
using Aqalnet.Infrastructure.Caching;
using Aqalnet.Infrastructure.Data;
using Aqalnet.Infrastructure.Email;
using Aqalnet.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aqalnet.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddTransient<IEmailService, EmailService>();
        var connectionString =
            configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            // sql server
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IPropertyRepository, PropertyRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(
            connectionString
        ));

        AddCaching(services, configuration);
        AddHealthChecks(services, configuration);
        return services;
    }

    public static void AddCaching(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("RedisCache")
            ?? throw new ArgumentNullException(nameof(configuration));

        services.AddStackExchangeRedisCache(options => options.Configuration = connectionString);
        services.AddSingleton<ICacheService, CacheService>();
    }

    public static void AddHealthChecks(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddHealthChecks()
            .AddSqlServer(configuration.GetConnectionString("DefaultConnection")!)
            .AddRedis(configuration.GetConnectionString("RedisCache")!);
    }
}
