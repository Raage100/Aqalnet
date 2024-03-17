using System.Data;
using Aqalnet.Application.Abstractions.Data;
using Npgsql;

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
        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        return connection;
    }
}
