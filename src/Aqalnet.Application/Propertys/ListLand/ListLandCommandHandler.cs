using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Propertys;
using Aqalnet.Domain.Propertys.ValueObjects;

namespace Aqalnet.Application.Propertys.ListLand;

internal sealed class ListLandCommandHandler : ICommandHandler<ListLandCommand, ListLandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPropertyRepository _propertyRepository;
    private readonly PricingService _pricingService;

    public ListLandCommandHandler(
        IPropertyRepository propertyRepository,
        IUnitOfWork unitOfWork,
        PricingService pricingService
    )
    {
        _propertyRepository = propertyRepository;
        _unitOfWork = unitOfWork;
        _pricingService = pricingService;
    }

    public async Task<Result<ListLandResponse>> Handle(
        ListLandCommand request,
        CancellationToken cancellationToken
    )
    {
        var land = Property.CreateLand(
            request.UserId,
            request.CityId,
            new Money(request.Price, Currency.FromCode(request.Currency)),
            new About(request.About),
            new Address(request.Street, 0),
            new Area(request.Area),
            new Longitude(request.Longitude),
            new Latitude(request.Latitude),
            _pricingService
        );

        _propertyRepository.Add(land);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result > 0
            ? new ListLandResponse(land.Id)
            : Result.Failure<ListLandResponse>(PropertyErrors.NotCreated);
    }
}
