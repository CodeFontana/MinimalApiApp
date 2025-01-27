using Dapper;

namespace DataAccessLibrary.Interfaces;

public interface IDataAccess
{
    Task<T?> QueryFirstOrDefaultAsync<T, U>(string storedProcedure, U parameters, string connectionString);
    Task<T?> QuerySingleOrDefaultAsync<T, U>(string storedProcedure, U parameters, string connectionString);
    Task<IEnumerable<T>> QueryMultipleAsync<T>(string storedProcedure, string connectionString);
    Task<IEnumerable<T>> QueryMultipleAsync<T, U>(string storedProcedure, U parameters, string connectionString);
    Task<int> ExecuteAsync(string storedProcedure, DynamicParameters parameters, string connectionString);
    Task<int> ExecuteAsync<T>(string storedProcedure, T parameters, string connectionString);
    Task<T> ExecuteAsync<T>(string storedProcedure, DynamicParameters parameters, string outputParameterName, string connectionString);
    Task<T?> ExecuteAsync<T, U>(string storedProcedure, U dbModel, string inputParameterName, string outputParameterName, string connectionString);
}