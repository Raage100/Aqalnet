using System.Data;
using Aqalnet.Application.Abstractions.Data;
using Microsoft.Data.SqlClient;

namespace Aqalnet.Infrastructure.Data;

internal class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection;
    }
}
