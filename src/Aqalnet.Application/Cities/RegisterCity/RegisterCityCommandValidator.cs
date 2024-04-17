using FluentValidation;

namespace Aqalnet.Application.Cities.RegisterCity;

internal sealed class RegisterCityCommandValidator : AbstractValidator<RegisterCityCommand>
{
    public RegisterCityCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
    }
}
