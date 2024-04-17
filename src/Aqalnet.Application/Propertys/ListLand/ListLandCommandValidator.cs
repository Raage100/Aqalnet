using FluentValidation;

namespace Aqalnet.Application.Propertys.ListLand;

internal sealed class ListLandCommandValidator : AbstractValidator<ListLandCommand>
{
    public ListLandCommandValidator()
    {
        RuleFor(x => x.CityId).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
    }
}
