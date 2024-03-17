using Aqalnet.Application.Abstractions.Data;
using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Application.Companies.GetCompany;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Companies;
using Dapper;

internal sealed class GetCompanyQueryHandler : IQueryHandler<GetCompanyQuery, CompanyResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetCompanyQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<CompanyResponse>> Handle(
        GetCompanyQuery request,
        CancellationToken cancellationToken
    )
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql =
            @"
          SELECT 
          id AS Id,
          company_name AS CompanyName
          FROM public.""Companies""
          WHERE id = @CompanyId";

        CompanyResponse? company = await connection.QueryFirstOrDefaultAsync<CompanyResponse>(
            sql,
            new { request.CompanyId }
        );

        if (company is null)
        {
            return Result.Failure<CompanyResponse>(CompanyErrors.NotFound);
        }
        return company;
    }
}
