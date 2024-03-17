using Aqalnet.Application.Abstractions.Caching;
using Aqalnet.Application.Abstractions.Clock;
using Aqalnet.Application.Abstractions.Data;
using Aqalnet.Application.Abstractions.Email;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Companies;
using Aqalnet.Domain.Propertys;
using Aqalnet.Domain.Users;
using Aqalnet.Infrastructure.Caching;
using Aqalnet.Infrastructure.Clock;
using Aqalnet.Infrastructure.Data;
using Aqalnet.Infrastructure.Email;
using Aqalnet.Infrastructure.Repositories;
using Asp.Versioning;
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
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention()
        );
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IPropertyRepository, PropertyRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(
            connectionString
        ));

        AddCaching(services, configuration);
        AddHealthChecks(services, configuration);
        AddVApiVersioning(services);
        return services;
    }

    private static void AddCaching(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("RedisCache")
            ?? throw new ArgumentNullException(nameof(configuration));

        services.AddStackExchangeRedisCache(options => options.Configuration = connectionString);
        services.AddSingleton<ICacheService, CacheService>();
    }

    private static void AddHealthChecks(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddHealthChecks()
            .AddNpgSql(configuration.GetConnectionString("DefaultConnection")!)
            .AddRedis(configuration.GetConnectionString("RedisCache")!);
    }

    private static void AddVApiVersioning(this IServiceCollection services)
    {
        services
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddMvc()
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });
    }
}
