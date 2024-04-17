using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Countries;
using Aqalnet.Domain.Users;

namespace Aqalnet.Application.Countries.RegisterCountry;

internal sealed class RegisterCountryCommandHandler : ICommandHandler<RegisterCountryCommand, Guid>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCountryCommandHandler(
        ICountryRepository countryRepository,
        IUnitOfWork unitOfWork
    )
    {
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        RegisterCountryCommand request,
        CancellationToken cancellationToken
    )
    {
        var country = Country.Create(Guid.NewGuid(), new Name(request.Name));
        if (country == null)
        {
            return Result.Failure<Guid>(CountryErrors.NotCreated);
        }

        _countryRepository.Add(country);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(country.Id);
    }
}
