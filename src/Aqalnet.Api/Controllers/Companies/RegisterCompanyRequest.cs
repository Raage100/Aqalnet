namespace Aqalnet.Api.Controllers.Companies;

public record RegisterCompanyRequest(
    string CompanyName,
    string Street,
    string City,
    string FirstName,
    string LastName,
    string Email,
    string MobileNumber,
    string logourl,
    string profilePictureUrl
);
