using FluentValidation;

namespace Aqalnet.Application.Countries.RegisterCountry;

internal sealed class RegisterCountryCommandValidator : AbstractValidator<RegisterCountryCommand>
{
    public RegisterCountryCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
    }
}
