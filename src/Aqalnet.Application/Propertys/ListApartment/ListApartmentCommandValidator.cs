using FluentValidation;

namespace Aqalnet.Application.Propertys.ListApartment;

internal sealed class ListApartmentCommandValidator : AbstractValidator<ListApartmentCommand>
{
    public ListApartmentCommandValidator()
    {
        RuleFor(x => x.CityId).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
    }
}
