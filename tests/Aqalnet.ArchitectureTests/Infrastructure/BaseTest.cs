using System.Reflection;
using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Infrastructure;

namespace Aqalnet.ArchitectureTests.Infrastructure;

public abstract class BaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(Entity).Assembly;
    protected static readonly Assembly ApplicationAssembly = typeof(IBaseCommand).Assembly;
    protected static readonly Assembly InfrastructureAssembly =
        typeof(ApplicationDbContext).Assembly;
    protected static readonly Assembly PresentationAssembly = typeof(Program).Assembly;
}
