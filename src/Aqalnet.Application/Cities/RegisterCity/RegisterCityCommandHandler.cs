using System.Data;
using Aqalnet.Application.Abstractions.Data;
using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Cities;
using Dapper;

namespace Aqalnet.Application.Cities.RegisterCity;

internal sealed class RegisterCityCommandHandler : ICommandHandler<RegisterCityCommand, Guid>
{
    private readonly ICityRepository _cityRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCityCommandHandler(ICityRepository cityRepository, IUnitOfWork unitOfWork)
    {
        _cityRepository = cityRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        RegisterCityCommand request,
        CancellationToken cancellationToken
    )
    {
        var existcity = await _cityRepository.GetCityByName(
            request.Name.ToLower(),
            cancellationToken
        );
        if (existcity != null)
        {
            return Result.Failure<Guid>(CityErrors.CityAlreadyExists);
        }

        var city = City.Create(Guid.NewGuid(), request.CountryId, new Name(request.Name));

        _cityRepository.Add(city);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(city.Id);
    }
}
