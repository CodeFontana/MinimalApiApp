using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces;
public interface IPersonRepository
{
    Task<int> Create(PersonModel person);
    Task DeleteAsync(int id);
    Task<PersonModel?> ReadAsync(int id);
    Task<IEnumerable<PersonModel>> ReadAllAsync();
    Task UpdateAsync(PersonModel person);
}