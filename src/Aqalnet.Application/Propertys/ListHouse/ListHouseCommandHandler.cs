using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Propertys;
using Aqalnet.Domain.Propertys.ValueObjects;

namespace Aqalnet.Application.Propertys.ListHouse;

internal sealed class ListHouseCommandHandler : ICommandHandler<ListHouseCommand, ListHouseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPropertyRepository _propertyRepository;
    private readonly PricingService _pricingService;

    public ListHouseCommandHandler(
        IUnitOfWork unitOfWork,
        IPropertyRepository propertyRepository,
        PricingService pricingService
    )
    {
        _unitOfWork = unitOfWork;
        _propertyRepository = propertyRepository;
        _pricingService = pricingService;
    }

    public async Task<Result<ListHouseResponse>> Handle(
        ListHouseCommand request,
        CancellationToken cancellationToken
    )
    {
        var house = Property.CreateHouse(
            request.UserId,
            request.CityId,
            new Money(request.Price, Currency.FromCode(request.Currency)),
            new About(request.About),
            new Address(request.Street, request.StreetNumber),
            new HasGarage(request.HasGarage),
            new HasParking(request.HasParking),
            new NumberOfRooms(request.NumberOfRooms),
            new NumberOfFloors(request.NumberOfFloors),
            new NumberOfToilets(request.NumberOfToilets),
            new YearBuilt(request.YéarBuilt),
            new Area(request.Area),
            _pricingService
        );

        _propertyRepository.Add(house);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result > 0
            ? new ListHouseResponse(house.Id)
            : Result.Failure<ListHouseResponse>(PropertyErrors.NotCreated);
    }
}
