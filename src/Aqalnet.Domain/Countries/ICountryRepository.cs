namespace Aqalnet.Domain.Countries;

public interface ICountryRepository
{
    Task<Country?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Country country);
}
