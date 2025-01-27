using System.Data;
using System.Runtime.InteropServices;
using System.Text.Json;
using Dapper;
using DataAccessLibrary.Interfaces;
using Microsoft.Data.SqlClient;

namespace DataAccessLibrary.DataAccess;

public sealed class SqlDataAccess : IDataAccess
{
    public async Task<T?> QueryFirstOrDefaultAsync<T, U>(string storedProcedure, U parameters, string connectionString)
    {
        using IDbConnection connection = new SqlConnection(connectionString);
        T? result = await connection.QueryFirstOrDefaultAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        return result;
    }

    public async Task<T?> QuerySingleOrDefaultAsync<T, U>(string storedProcedure, U parameters, string connectionString)
    {
        using IDbConnection connection = new SqlConnection(connectionString);
        T? result = await connection.QuerySingleOrDefaultAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        return result;
    }

    public async Task<IEnumerable<T>> QueryMultipleAsync<T>(string storedProcedure, string connectionString)
    {
        using IDbConnection connection = new SqlConnection(connectionString);
        IEnumerable<T> result = await connection.QueryAsync<T>(storedProcedure, commandType: CommandType.StoredProcedure);
        return result;
    }

    public async Task<IEnumerable<T>> QueryMultipleAsync<T, U>(string storedProcedure, U parameters, string connectionString)
    {
        using IDbConnection connection = new SqlConnection(connectionString);
        IEnumerable<T> result = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        return result;
    }

    public async Task<int> ExecuteAsync(string storedProcedure, DynamicParameters parameters, string connectionString)
    {
        using IDbConnection connection = new SqlConnection(connectionString);
        var result = await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        return result;
    }

    public async Task<int> ExecuteAsync<T>(string storedProcedure, T parameters, string connectionString)
    {
        using IDbConnection connection = new SqlConnection(connectionString);
        var result = await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        return result;
    }

    public async Task<T> ExecuteAsync<T>(string storedProcedure, DynamicParameters parameters, string outputParameterName, string connectionString)
    {
        using IDbConnection connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<T>(outputParameterName);
    }

    public async Task<T?> ExecuteAsync<T, U>(string storedProcedure, U dbEntity, string inputParameterName, string outputParameterName, string connectionString)
    {
        string json = JsonSerializer.Serialize(dbEntity);
        DynamicParameters parameters = new();
        parameters.Add(inputParameterName, json);
        parameters.Add(name: outputParameterName, size: Marshal.SizeOf(typeof(T)), direction: ParameterDirection.Output);

        using IDbConnection connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        string output = parameters.Get<string>(outputParameterName);
        if (string.IsNullOrWhiteSpace(output))
        {
            return default;
        }

        return (T)Convert.ChangeType(output, typeof(T));
    }
}