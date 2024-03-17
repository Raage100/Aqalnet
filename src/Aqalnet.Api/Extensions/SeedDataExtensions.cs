using System.Data;
using Aqalnet.Application.Abstractions.Data;
using Bogus;
using Dapper;

namespace Aqalnet.Api.Extensions;

public static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ISqlConnectionFactory sqlConnectionFactory =
            scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
        using IDbConnection connection = sqlConnectionFactory.CreateConnection();

        const string checkSql = "SELECT COUNT(*) FROM public.\"Companies\"";
        var count = connection.ExecuteScalar<int>(checkSql);
        if (count > 0)
        {
            return;
        }

        var faker = new Faker();

        List<object> companies = new();

        for (int i = 0; i < 100; i++)
        {
            companies.Add(
                new
                {
                    Id = Guid.NewGuid(),
                    CompanyName = faker.Company.CompanyName(),
                    Street = faker.Address.StreetName(),
                    City = faker.Address.City()
                }
            );
        }

        var company1 = new
        {
            Id = Guid.Parse("30e3c9d3-6e9d-4a2f-af1f-8d8de6a61f8d"),
            CompanyName = "Raage",
            Street = faker.Address.StreetName(),
            City = faker.Address.City()
        };

        companies.Add(company1);

        const string sql =
            @"
                INSERT INTO public.""Companies""
                (id, company_name, street, city)
                VALUES(@Id, @CompanyName, @Street, @City);
            ";

        connection.Execute(sql, companies);
    }
}
