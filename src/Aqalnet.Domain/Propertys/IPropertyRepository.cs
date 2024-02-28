namespace Aqalnet.Domain.Propertys;

public interface IPropertyRepository
{
    Task<Property?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Property property);
}
