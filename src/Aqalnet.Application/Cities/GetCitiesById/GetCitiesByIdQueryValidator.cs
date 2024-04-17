using FluentValidation;

namespace Aqalnet.Application.Cities.GetCitiesById;

internal sealed class GetCitiesByIdQueryValidator : AbstractValidator<GetCitiesByIdQuery>
{
    public GetCitiesByIdQueryValidator()
    {
        RuleFor(x => x.CountryId).NotEmpty().WithMessage("Country Id is required");
    }
}
