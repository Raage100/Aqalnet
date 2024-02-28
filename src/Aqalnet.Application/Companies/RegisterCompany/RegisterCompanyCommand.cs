using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Companies;

namespace Aqalnet.Application.Companies.RegisterCompany;

public record RegisterCompanyCommand(
    string CompanyName,
    Address Address,
    string firstName,
    string lastName,
    string email,
    string mobileNumber
) : ICommand<Guid>;
