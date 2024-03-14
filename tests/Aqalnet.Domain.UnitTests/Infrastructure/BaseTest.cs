using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.UnitTests.Infrastructure;

public abstract class BaseTest
{
    public static T AssertDomainEventWasPublished<T>(Entity entity)
        where T : IDomainEvent
    {
        var domainEvent = entity.GetDomainEvents().OfType<T>().SingleOrDefault();
        if (domainEvent == null)
        {
            throw new Exception($"Expected domain event of type {typeof(T)} was not published");
        }
        return domainEvent;
    }
}
