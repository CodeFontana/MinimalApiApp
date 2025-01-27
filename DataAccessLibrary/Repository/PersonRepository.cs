using System.Data;
using Dapper;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary.Repository;

public sealed class PersonRepository : IPersonRepository
{
    private readonly IDataAccess _db;
    private readonly string _connectionString;

    public PersonRepository(IConfiguration config, IDataAccess db)
    {
        _db = db;
        _connectionString = config.GetConnectionString("Default")
            ?? throw new Exception("Default connection string not found in configuration");
    }

    public async Task<int> Create(PersonModel person)
    {
        DynamicParameters p = new();
        p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);
        p.Add("FirstName", person.FirstName);
        p.Add("LastName", person.LastName);
        await _db.ExecuteAsync("dbo.spPerson_Create", p, _connectionString);
        return p.Get<int>("Id");
    }

    public async Task<PersonModel?> ReadAsync(int id)
    {
        PersonModel? result = await _db.QueryFirstOrDefaultAsync<PersonModel, dynamic>(
            "dbo.spPerson_Read",
            new { Id = id },
            _connectionString);
        return result;
    }

    public Task<IEnumerable<PersonModel>> ReadAllAsync()
    {
        return _db.QueryMultipleAsync<PersonModel, dynamic>(
            "dbo.spPerson_ReadAll",
            new { },
            _connectionString);
    }

    public Task UpdateAsync(PersonModel person)
    {
        return _db.ExecuteAsync("dbo.spPerson_Update", person, _connectionString);
    }

    public Task DeleteAsync(int id)
    {
        return _db.ExecuteAsync("dbo.spPerson_Delete", new { Id = id }, _connectionString);
    }
}
