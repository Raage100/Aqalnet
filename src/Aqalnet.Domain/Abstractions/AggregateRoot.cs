namespace Aqalnet.Domain.Abstractions;

public abstract class AggregateRoot : Entity
{
    protected AggregateRoot(Guid id)
        : base(id) { }

    public AggregateRoot() { }
}
