using Aqalnet.Application.Abstractions.Data;
using Aqalnet.Application.Abstractions.Email;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Companies;
using Aqalnet.Domain.Propertys;
using Aqalnet.Domain.Users;
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

        return services;
    }
}
