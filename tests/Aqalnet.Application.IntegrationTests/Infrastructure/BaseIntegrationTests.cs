using Aqalnet.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Aqalnet.Application.IntegrationTests.Infrastructure;

public abstract class BaseIntegrationTests : IClassFixture<IntegrationTestWebAppFactory>
{
    private readonly IServiceScope _Scope;
    protected readonly ISender Sender;
    protected readonly ApplicationDbContext DbContext;

    protected BaseIntegrationTests(IntegrationTestWebAppFactory factory)
    {
        _Scope = factory.Services.CreateScope();
        Sender = _Scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = _Scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }
}
