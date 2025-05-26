using Dapper;
using Npgsql;
using Microsoft.Extensions.Configuration;
using System.Data;
using BankingApp.Core.Interfaces;

namespace BankingApp.Core.DataAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(
        string sql,
        U parameters,
        string connectionId = "Default")
    {
        var connectionString = _config.GetConnectionString(connectionId);

        using IDbConnection connection = new NpgsqlConnection(connectionString);

        return await connection.QueryAsync<T>(sql, parameters); // No StoredProcedure
    }

    public async Task SaveData<T>(
        string sql,
        T parameters,
        string connectionId = "Default")
    {
        using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(sql, parameters); // No StoredProcedure
    }
}
