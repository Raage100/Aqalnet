using Aqalnet.Application.Abstractions.Data;
using Aqalnet.Infrastructure;
using Aqalnet.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Testcontainers.MsSql;
using Testcontainers.Redis;


namespace Aqalnet.Application.IntegrationTests.Infrastructure;
public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private static readonly MsSqlConfiguration configuration = new MsSqlConfiguration(
            database: "Raqis",
            username: "sa",
            password: "Admin@123"
           );

    private static ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
        // Configure additional logging sources here
    });

    // Create an ILogger instance for MsSqlContainer using the loggerFactory
    private static ILogger<MsSqlContainer> logger = loggerFactory.CreateLogger<MsSqlContainer>();

    private readonly MsSqlContainer _dbcontainer = new MsSqlContainer(configuration, logger);


    private readonly RedisContainer _redisContainer = new RedisBuilder()
        .WithImage("redis:latest")
        .Build();

    public async Task InitializeAsync()
    {
        await _dbcontainer.StartAsync();
        await _redisContainer.StartAsync();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {

        
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<ApplicationDbContext>));
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(_dbcontainer.GetConnectionString());
            });

            services.RemoveAll(typeof(ISqlConnectionFactory));
            services.AddSingleton<ISqlConnectionFactory>(_ => 
            new SqlConnectionFactory(_dbcontainer.GetConnectionString()));

            services.Configure<RedisCacheOptions>(redisCacheOptions =>
            {
                redisCacheOptions.Configuration = _redisContainer.GetConnectionString();
            });
        });
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await _dbcontainer.StopAsync();
        await _redisContainer.StopAsync();

    }
}
