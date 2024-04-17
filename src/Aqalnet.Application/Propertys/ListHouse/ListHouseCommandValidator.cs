using FluentValidation;

namespace Aqalnet.Application.Propertys.ListHouse;

internal sealed class ListHouseCommandValidator : AbstractValidator<ListHouseCommand>
{
    public ListHouseCommandValidator()
    {
        RuleFor(x => x.CityId).NotEmpty();
    }
}
