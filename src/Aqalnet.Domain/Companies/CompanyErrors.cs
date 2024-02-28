using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Companies;

public static class CompanyErrors
{
    public static Error NotFound =>
        new("Company.Found", "The company with the specified identifier was not found");
}
