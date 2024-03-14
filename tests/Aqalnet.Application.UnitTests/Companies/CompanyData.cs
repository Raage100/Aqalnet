using Aqalnet.Domain.Companies;
using Aqalnet.Domain.Users;

namespace Aqalnet.Application.UnitTests.Companies;

internal static class CompanyData
{
    public static readonly string CompanyName = "companyName";
    public static readonly Address Address = new("street", "city");
    public static readonly Logo Logo = new("url");
    public static readonly string FirstName = "First";
    public static readonly string LastName = "Last";
    public static readonly string Email = "email@hotmail.com";
    public static readonly string MobilePhone = "09388732";
    public static readonly ProfilePicture ProfilePicture = new("url");

    public static Company Create() =>
        Company.Create(
            CompanyName,
            Address,
            Logo,
            FirstName,
            LastName,
            Email,
            MobilePhone,
            ProfilePicture
        );
}
