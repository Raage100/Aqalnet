using FluentValidation;

namespace Aqalnet.Application.Companies.RegisterCompany;


internal class RegisterCompanyCommandValidator : AbstractValidator<RegisterCompanyCommand>
{
    public RegisterCompanyCommandValidator()
    {
        RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Address).NotNull().WithMessage("Address is required");
        RuleFor(x => x.Address.Street).NotEmpty().WithMessage("Street is required");
        RuleFor(x => x.Address.City).NotEmpty().WithMessage("City is required");
    }
}