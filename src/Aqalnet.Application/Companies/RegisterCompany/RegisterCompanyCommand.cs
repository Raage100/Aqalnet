using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Companies;
using Aqalnet.Domain.Users;

namespace Aqalnet.Application.Companies.RegisterCompany;

public record RegisterCompanyCommand(
    string CompanyName,
    Address Address,
    string firstName,
    string lastName,
    string email,
    string mobileNumber,
    Logo Logo,
    ProfilePicture ProfilePicture
) : ICommand<Guid>;
