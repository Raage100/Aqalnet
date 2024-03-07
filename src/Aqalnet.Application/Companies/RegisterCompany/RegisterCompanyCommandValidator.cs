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
        RuleFor(x => x.firstName).NotEmpty().WithMessage("First Name is required");
        RuleFor(x => x.lastName).NotEmpty().WithMessage("Last Name is required");
        RuleFor(x => x.email).NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.mobileNumber).NotEmpty().WithMessage("Mobile Number is required");
    }
}
