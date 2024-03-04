
using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Companies;
using Aqalnet.Domain.Users;

namespace Aqalnet.Application.Companies;

public record RegisterAgentCommand(Guid companyId,string firstName, string lastName, string email, string mobileNumber, string title, ProfilePicture Profile) : ICommand<RegisterAgentReponse>;