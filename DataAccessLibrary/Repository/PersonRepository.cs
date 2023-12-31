﻿using Dapper;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using System.Data;

namespace DataAccessLibrary.Repository;

public sealed class PersonRepository : IPersonRepository
{
    private readonly IDataAccess _db;

    public PersonRepository(IDataAccess db)
    {
        _db = db;
    }

    public async Task<int> Create(PersonModel person)
    {
        DynamicParameters p = new();
        p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);
        p.Add("FirstName", person.FirstName);
        p.Add("LastName", person.LastName);
        await _db.SaveDataAsync("dbo.spPerson_Create", p, "Default");
        return p.Get<int>("Id");
    }

    public async Task<PersonModel?> ReadAsync(int id)
    {
        IEnumerable<PersonModel> result = await _db.LoadDataAsync<PersonModel, dynamic>(
            "dbo.spPerson_Read", 
            new { Id = id }, 
            "Default");
        return result.FirstOrDefault();
    }

    public Task<IEnumerable<PersonModel>> ReadAllAsync()
    {
        return _db.LoadDataAsync<PersonModel, dynamic>(
            "dbo.spPerson_ReadAll", 
            new { }, 
            "Default");
    }

    public Task UpdateAsync(PersonModel person)
    {
        return _db.SaveDataAsync("dbo.spPerson_Update", person, "Default");
    }

    public Task DeleteAsync(int id)
    {
        return _db.SaveDataAsync("dbo.spPerson_Delete", new { Id = id }, "Default");
    }
}
