using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Cities;
using Aqalnet.Domain.Propertys;
using Aqalnet.Domain.Propertys.ValueObjects;

namespace Aqalnet.Application.Propertys.ListApartment;

internal sealed class ListApartmentCommandHandler
    : ICommandHandler<ListApartmentCommand, ListApartmentResponse>
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly ICityRepository _cityRepository;
    private readonly PricingService _pricingService;
    private readonly IUnitOfWork _unitOfWork;

    public ListApartmentCommandHandler(
        IPropertyRepository propertyRepository,
        ICityRepository cityRepository,
        IUnitOfWork unitOfWork,
        PricingService pricingService
    )
    {
        _propertyRepository = propertyRepository;
        _cityRepository = cityRepository;
        _unitOfWork = unitOfWork;
        _pricingService = pricingService;
    }

    public async Task<Result<ListApartmentResponse>> Handle(
        ListApartmentCommand request,
        CancellationToken cancellationToken
    )
    {
        var apartment = Property.CreateApartment(
            request.UserId,
            request.CityId,
            new Money(request.Price, Currency.FromCode(request.Currency)),
            new About(request.About),
            new Address(request.Street, request.StreetNumber),
            new HasParking(request.HasParking),
            new HasBalcony(request.HasBalcony),
            new Floor(request.Floor),
            new HasElevator(request.HasElevator),
            new YearBuilt(request.YearBuilt),
            new NumberOfRooms(request.NumberOfRooms),
            new NumberOfToilets(request.NumberOfToilets),
            new Area(request.Area),
            _pricingService
        );

        _propertyRepository.Add(apartment);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result > 0
            ? new ListApartmentResponse(apartment.Id)
            : Result.Failure<ListApartmentResponse>(PropertyErrors.NotCreated);
    }
}
