namespace Aqalnet.Domain.Cities;

public interface ICityRepository
{
    Task<City?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(City city);

    Task<City?> GetCityByName(string name, CancellationToken cancellationToken = default);
}
